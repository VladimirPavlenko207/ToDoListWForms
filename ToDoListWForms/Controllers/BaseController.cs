using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWForms.Helpers;
using ToDoListWForms.Models.Responses;
using ToDoListWForms.Modes;

namespace ToDoListWForms.Controllers
{
    public abstract class BaseController
    {
        protected static IMode Mode { get; set; }

        /// <summary>
        /// Асинхронная загрузка
        /// </summary>
        /// <returns></returns>
        public abstract Task<bool> LoadAsync();
     
        /// <summary>
        /// Отображение
        /// </summary>
        public abstract void Display();
        public abstract Task<string> UpdateAsync();
       
        public abstract void SetAddMode();
        public abstract void SetLoadMode(); 
        public abstract void SetEditMode();
        public abstract void SetRemoveMode();
        public abstract void AddModeTrigger();
        public abstract void EditModeTrigger();
        public async Task<string> UpdateAndLoadAsync()
        {
            var message = await UpdateAsync();
            SetVirtualLoadMode();
            if (string.IsNullOrEmpty(message))
            {
                Display();
                return string.Empty;
            }
            await LoadAsync();
            Display();
            return message;
        }

        protected abstract void SetVirtualLoadMode();
    }
}
