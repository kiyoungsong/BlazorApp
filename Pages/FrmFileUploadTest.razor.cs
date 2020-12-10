using BlazorApp.Services;
using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public partial class FrmFileUploadTest
    {
        [Inject]
        public IFileUploadService FileUploadServiceReference { get; set; }

        private IFileListEntry[] selectedFiles;
        protected void HandleSelection(IFileListEntry[] files)
        {
            selectedFiles = files;
        }

        protected async void UploadClick()
        {
            var file = selectedFiles.FirstOrDefault();

            if(file != null)
            {
                await FileUploadServiceReference.UploadAsync(file); //wwwroot 업로드 폴더에 업로드가 된다.
            }
        }
    }
}
