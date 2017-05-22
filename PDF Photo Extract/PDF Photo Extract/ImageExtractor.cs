/* ------------------------------------------------------------------------------
  PDF Photo Extract
  This tool will extract any images found in a single PDF file,
  and export them to a folder of the user's choosing.
 
  Copyright (C) 2016, 2017 Adam Elders
  Contact - Email: aelders@sfrep.com
  Full AGPL License can be found here: \<Installation Folder>\AGPL.txt
  For example: C:\Users\Adam\Desktop\PDF Photo Extract\AGPL.txt
  ------------------------------------------------------------------------------
  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU Affero General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.
 
  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
  GNU Affero General Public License for more details.

  You should have received a copy of the GNU Affero General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
  ------------------------------------------------------------------------------ */

using System;
using System.IO;

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PdfImage.Helpers {

    public static class PdfHelper {
        public static int ExtractImagesFromFile(string pdfFileName, string outputFilePrefix, string outputDirectory, bool overwriteExistingImages) {
            return ImageExtractor.ExtractImagesFromFile(pdfFileName, outputFilePrefix, outputDirectory, overwriteExistingImages);
        }
    }


    /// <summary>
    /// Helper lass to dump all images from a PDF into separate files
    /// </summary>
    internal class ImageExtractor : IRenderListener {
        int _currentPage = 1;
        int _imageCount = 0;
        readonly string _outputFilePrefix;
        readonly string _outputFolder;
        readonly bool _overwriteExistingFiles;

        private ImageExtractor(string outputFilePrefix, string outputFolder, bool overwriteExistingFiles) {
            _outputFilePrefix = outputFilePrefix;
            _outputFolder = outputFolder;
            _overwriteExistingFiles = overwriteExistingFiles;
        }

        /// <summary>
        /// Extract all images from a PDF file
        /// </summary>
        /// <param name="pdfPath">Full path and file name of PDF file</param>
        /// <param name="outputFilePrefix">Basic name of exported files. If null then uses same name as PDF file.</param>
        /// <param name="outputFolder">Where to save images. If null or empty then uses same folder as PDF file.</param>
        /// <param name="overwriteExistingFiles">True to overwrite existing image files, false to skip past them</param>
        /// <returns>Count of number of images extracted.</returns>
        public static int ExtractImagesFromFile(string pdfPath, string outputFilePrefix, string outputFolder, bool overwriteExistingFiles) {
            // Handle setting of any default values
            outputFilePrefix = outputFilePrefix ?? System.IO.Path.GetFileNameWithoutExtension(pdfPath);
            outputFolder = String.IsNullOrEmpty(outputFolder) ? System.IO.Path.GetDirectoryName(pdfPath) : outputFolder;

            var instance = new ImageExtractor(outputFilePrefix, outputFolder, overwriteExistingFiles);

            using (var pdfReader = new PdfReader(pdfPath)) {
                if (pdfReader.IsEncrypted())
                    throw new ApplicationException(pdfPath + " is encrypted.");

                var pdfParser = new PdfReaderContentParser(pdfReader);

                while (instance._currentPage <= pdfReader.NumberOfPages) {
                    pdfParser.ProcessContent(instance._currentPage, instance);

                    instance._currentPage++;
                }
            }

            return instance._imageCount;
        }

        #region Implementation of IRenderListener

        public void BeginTextBlock() { }
        public void EndTextBlock() { }
        public void RenderText(TextRenderInfo renderInfo) { }

        public void RenderImage(ImageRenderInfo renderInfo) {
            var imageObject = renderInfo.GetImage();

            var imageFileName = String.Format("{0}_{1}_{2}.{3}", _outputFilePrefix, _currentPage, _imageCount, imageObject.GetFileType());
            var imagePath = System.IO.Path.Combine(_outputFolder, imageFileName);

            if (_overwriteExistingFiles || !File.Exists(imagePath)) {
                var imageRawBytes = imageObject.GetImageAsBytes();

                File.WriteAllBytes(imagePath, imageRawBytes);

            }

            // Subtle: Always increment even if file is not written. This ensures consistency should only some
            //   of a PDF file's images actually exist.
            _imageCount++;
        }

        #endregion // Implementation of IRenderListener

    }
}