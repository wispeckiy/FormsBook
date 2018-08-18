namespace Events
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";

            //
            // Click
            //
            this.Click += new System.EventHandler(this.click);

            // 
            // Rezize
            //
            this.Resize += new System.EventHandler(this.resize);
            //
            // Resize begin
            //
            this.ResizeBegin += new System.EventHandler(this.resize_Begin);

            //
            // Resize end
            //
            this.ResizeEnd += new System.EventHandler(this.resize_End);
            //
            // Load
            //
            this.Load += new System.EventHandler(this.load);
            // 
            // Close
            //
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_Closed);
            // 
            // Language Changed
            //
            this.InputLanguageChanged += new System.Windows.Forms.InputLanguageChangedEventHandler(this.form_LanguageChanged);
        }

        #endregion
    }
}

