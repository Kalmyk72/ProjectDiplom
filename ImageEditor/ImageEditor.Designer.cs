namespace ImageEditor
{
    partial class ImageEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_open_image = new Button();
            picbox_unedit_image = new PictureBox();
            picbox_type_transform = new PictureBox();
            btn_color_transform = new Button();
            trackbar_changeSaturation = new TrackBar();
            label3 = new Label();
            btn_Crop = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picbox_unedit_image).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picbox_type_transform).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackbar_changeSaturation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_open_image
            // 
            btn_open_image.Location = new Point(11, 8);
            btn_open_image.Name = "btn_open_image";
            btn_open_image.Size = new Size(346, 23);
            btn_open_image.TabIndex = 0;
            btn_open_image.Text = "Открыть изображение";
            btn_open_image.UseVisualStyleBackColor = true;
            btn_open_image.Click += btn_open_image_Click;
            // 
            // picbox_unedit_image
            // 
            picbox_unedit_image.Location = new Point(11, 37);
            picbox_unedit_image.Name = "picbox_unedit_image";
            picbox_unedit_image.Size = new Size(346, 299);
            picbox_unedit_image.SizeMode = PictureBoxSizeMode.Zoom;
            picbox_unedit_image.TabIndex = 1;
            picbox_unedit_image.TabStop = false;
            // 
            // picbox_type_transform
            // 
            picbox_type_transform.Location = new Point(363, 37);
            picbox_type_transform.Name = "picbox_type_transform";
            picbox_type_transform.Size = new Size(346, 299);
            picbox_type_transform.SizeMode = PictureBoxSizeMode.Zoom;
            picbox_type_transform.TabIndex = 2;
            picbox_type_transform.TabStop = false;
            // 
            // btn_color_transform
            // 
            btn_color_transform.Location = new Point(363, 8);
            btn_color_transform.Name = "btn_color_transform";
            btn_color_transform.Size = new Size(346, 23);
            btn_color_transform.TabIndex = 3;
            btn_color_transform.Text = "Повышение контраста";
            btn_color_transform.UseVisualStyleBackColor = true;
            btn_color_transform.Click += btn_color_transform_Click;
            // 
            // trackbar_changeSaturation
            // 
            trackbar_changeSaturation.Location = new Point(13, 357);
            trackbar_changeSaturation.Maximum = 255;
            trackbar_changeSaturation.Name = "trackbar_changeSaturation";
            trackbar_changeSaturation.Size = new Size(346, 45);
            trackbar_changeSaturation.TabIndex = 6;
            trackbar_changeSaturation.ValueChanged += HSV_Trackbar;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(136, 339);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 9;
            label3.Text = "Баланс белого";
            // 
            // btn_Crop
            // 
            btn_Crop.Location = new Point(363, 342);
            btn_Crop.Name = "btn_Crop";
            btn_Crop.Size = new Size(346, 23);
            btn_Crop.TabIndex = 10;
            btn_Crop.Text = "Обрезать изображение";
            btn_Crop.UseVisualStyleBackColor = true;
            btn_Crop.Click += btn_Crop_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(715, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(342, 299);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 739);
            Controls.Add(pictureBox1);
            Controls.Add(btn_Crop);
            Controls.Add(label3);
            Controls.Add(trackbar_changeSaturation);
            Controls.Add(btn_color_transform);
            Controls.Add(picbox_type_transform);
            Controls.Add(picbox_unedit_image);
            Controls.Add(btn_open_image);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picbox_unedit_image).EndInit();
            ((System.ComponentModel.ISupportInitialize)picbox_type_transform).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackbar_changeSaturation).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_open_image;
        private PictureBox picbox_unedit_image;
        private PictureBox picbox_type_transform;
        private Button btn_color_transform;
        private TrackBar trackbar_changeSaturation;
        private Label label3;
        private Button btn_Crop;
        private PictureBox pictureBox1;
    }
}
