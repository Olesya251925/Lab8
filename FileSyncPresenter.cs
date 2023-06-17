using System;
using WindowsFormsApp8;
using FileSyncApp;

namespace FileSyncApp
{
    public class FileSyncPresenter
    {
        private readonly IFileSyncView view;
        private readonly FileSyncModel model;

        public FileSyncPresenter(IFileSyncView view, FileSyncModel model)
        {
            this.view = view;
            this.model = model;

            this.view.SyncRequested += View_SyncRequested;
        }

        private void View_SyncRequested(object sender, EventArgs e)
        {
            string status = model.CheckChanges();
            view.DisplayStatus(status);
        }
    }
}
