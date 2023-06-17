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
            
            // Подписываемся на событие SyncRequested представления
            this.view.SyncRequested += View_SyncRequested;
        }
        
        // Обработчик события SyncRequested представления
        private void View_SyncRequested(object sender, EventArgs e)
        {
             // Проверяем изменения в модели
            string status = model.CheckChanges();
            
             // Отображаем статус синхронизации в представлении
            view.DisplayStatus(status);
        }
    }
}
