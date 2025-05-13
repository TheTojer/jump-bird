namespace game;

using Timer = System.Windows.Forms.Timer;
using ResourceManager = System.ComponentModel.ComponentResourceManager;
using Container = System.ComponentModel.Container;

partial class MainWindow
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
    PictureBox bird;
    PictureBox bottomPipe;
    PictureBox topPipe;
    PictureBox ground;
    Label scoreLabel;
    Label scoreText;
    Timer gameTimer;

    private void InitializeComponent()
    {
        components = new Container();
        bird = new PictureBox();
        bottomPipe = new PictureBox();
        topPipe = new PictureBox();
        ground = new PictureBox();
        scoreLabel = new Label();
        scoreText = new Label();
        gameTimer = new Timer(components);

        ((System.ComponentModel.ISupportInitialize)(topPipe)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(bottomPipe)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(bird)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(ground)).BeginInit();
        SuspendLayout();
        
        bird.Name = "bird";
        bird.TabIndex = 0;
        bird.TabStop = false;

        bird.BackColor = Color.Transparent;
        if (File.Exists(@"images\bird.png"))
            bird.Image = Image.FromFile(@"images\bird.png");

        bird.Location = new Point(25, 226);
        bird.Size = new Size(134, 99);
        bird.SizeMode = PictureBoxSizeMode.StretchImage;
        
        bottomPipe.Name = "bottomPipe";
        bottomPipe.TabIndex = 1;
        bottomPipe.TabStop = false;

        bottomPipe.BackColor = Color.Transparent;
        if (File.Exists(@"images\pipe.png"))
            bottomPipe.Image = Image.FromFile(@"images\pipe.png");

        bottomPipe.Location = new Point(543, 475);
        bottomPipe.Size = new Size(172, 228);
        bottomPipe.SizeMode = PictureBoxSizeMode.StretchImage;
        
        topPipe.Name = "topPipe";
        topPipe.TabIndex = 2;
        topPipe.TabStop = false;
        topPipe.UseWaitCursor = true;

        topPipe.BackColor = Color.Transparent;
        if (File.Exists(@"images\pipedown.png"))
            topPipe.Image = Image.FromFile(@"images\pipedown.png");

        topPipe.Location = new Point(831, 0);
        topPipe.Size = new Size(161, 261);
        topPipe.SizeMode = PictureBoxSizeMode.StretchImage;
        
        ground.Name = "ground";
        ground.TabIndex = 3;
        ground.TabStop = false;

        ground.BackColor = Color.Transparent;
        if (File.Exists(@"images\ground.png"))
            ground.Image = Image.FromFile(@"images\ground.png");

        ground.Location = new Point(-6, 645);
        ground.Size = new Size(1131, 194);
        ground.SizeMode = PictureBoxSizeMode.StretchImage;

        scoreLabel.Name = "scoreLabel";
        scoreLabel.Text = "Score:";
        scoreLabel.TabIndex = 4;

        scoreLabel.AutoSize = true;
        scoreLabel.Location = new Point(12, 9);
        scoreLabel.Size = new Size(175, 59);

        scoreLabel.BackColor = Color.Green;
        scoreLabel.ForeColor = SystemColors.ControlLightLight;

        scoreLabel.Font = new Font
        (
            "Arial", 14, 
            FontStyle.Regular,
            GraphicsUnit.Point
        );

        scoreText.Name = "scoreText";
        scoreText.Text = "0";
        scoreText.TabIndex = 5;

        scoreText.AutoSize = true;
        scoreText.Location = new Point(193, 9);
        scoreText.Size = new Size(55, 59);

        scoreText.BackColor = Color.Green;
        scoreText.ForeColor = SystemColors.ControlLightLight;

        scoreText.Font = new Font
        (
            "Arial", 14,
            FontStyle.Regular,
            GraphicsUnit.Point
        );

        gameTimer.Enabled = true;
        gameTimer.Interval = 10;
        gameTimer.Tick += new EventHandler(gameTimer_Tick);

        Name = "MainWindow";
        Text = "Jump Bird";

        AutoScaleDimensions = new SizeF(7, 15);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1111, 740);

        BackColor = Color.LightSkyBlue;
        BackgroundImageLayout = ImageLayout.Stretch;
        ForeColor = Color.Cornsilk;

        Controls.Add(scoreText);
        Controls.Add(scoreLabel);
        Controls.Add(topPipe);
        Controls.Add(ground);
        Controls.Add(bird);
        Controls.Add(bottomPipe);

        KeyDown += new KeyEventHandler(onKeyDown);
        KeyUp += new KeyEventHandler(onKeyUp);

        ((System.ComponentModel.ISupportInitialize)(topPipe)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(bottomPipe)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(bird)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(ground)).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
