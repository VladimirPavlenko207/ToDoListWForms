using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListWForms.Helpers
{
    /// <summary>
    /// Класс создает подсказки над элементами управления
    /// </summary>
    public static class ToolTipsCreator
    {
        internal static void SetAllToolTips()
        {
            CategoryToolTips();
            TagToolTips();
            TaskToolTips(); 
        }

        private static void TaskToolTips()
        {
            SetToolTip(MainForm.GetInstance().buttonSaveTask, "Сохранить изменения в текущей задаче");
            SetToolTip(MainForm.GetInstance().buttonDeleteTask, "Удалить текущую задачу");
            SetToolTip(MainForm.GetInstance().buttonRightAddTag, "Добавить метку текущей задаче");
            SetToolTip(MainForm.GetInstance().buttonRightRemoveTag, "Удалить метку в текущей задаче");
        }

        private static void CategoryToolTips()
        {
            SetToolTip(MainForm.GetInstance().buttonAddCategory, "Создать новую категорию");
            SetToolTip(MainForm.GetInstance().buttonRemoveCategory, "Удалить категорию");
            SetToolTip(MainForm.GetInstance().buttonEditCategory, "Редактировать категорию");
            SetToolTip(MainForm.GetInstance().textBoxCategory, "После ввода текста нажмите Enter");
        }

        private static void SetToolTip(Control control, string str)
        {
            ToolTip toolTip = new();
            toolTip.SetToolTip(control, str);
        }

        private static void TagToolTips()
        {
            SetToolTip(MainForm.GetInstance().buttonAddTag, "Создать новую метку");
            SetToolTip(MainForm.GetInstance().buttonRemoveTag, "Удалить метку");
            SetToolTip(MainForm.GetInstance().buttonEditTag, "Редактировать метку");
            SetToolTip(MainForm.GetInstance().textBoxTag, "После ввода текста нажмите Enter");
        }
    }
}
