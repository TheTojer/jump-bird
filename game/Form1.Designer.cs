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
    PictureBox[] pipes;
    PictureBox ground;
    Label scoreLabel;
    Label scoreText;
    Timer gameTimer;

    private void InitializeComponent()
    {
        components = new Container();
        bird = new PictureBox();

        pipes = new PictureBox[20];

        ground = new PictureBox();
        scoreLabel = new Label();
        scoreText = new Label();
        gameTimer = new Timer(components);

        for (int i = 0; i < 10; i++)
            pipes.Append(new PictureBox());

        foreach (var pipe in pipes)
            BeginInit(pipe);

        BeginInit(bird);
        BeginInit(ground);

        SuspendLayout();
        
        bird.Name = "bird";
        bird.TabStop = false;

        bird.BackColor = Color.Transparent;
        if (File.Exists(@"images\bird.png"))
            bird.Image = Image.FromFile(@"images\bird.png");

        bird.Location = new Point(25, 226);
        bird.Size = new Size(134, 99);
        bird.SizeMode = PictureBoxSizeMode.StretchImage;
        
        for (int i = 0; i < 20; i++)
        {
            pipes[i].Name = i % 2 == 0 ? "bottomPipe" : "topPipe" + i;
            pipes[i].TabStop = false;
            pipes[i].BackColor = Color.Transparent;
            pipes[i].Size = new Size(190, 556);
            pipes[i].SizeMode = PictureBoxSizeMode.StretchImage;
            pipes[i].Location = new Point(500 + (int)(i / 2) * 100, i % 2 == 0 ? 0 : 300);
        }

        if (File.Exists(@"images\b_pipe.png"))
            for (int i = 0; i < 20; i += 2)
                pipes[i].Image = Image.FromFile(@"images\b_pipe.png");

        if (File.Exists(@"images\t_pipe.png"))
            for (int i = 1; i < 20; i += 2)
                pipes[i].Image = Image.FromFile(@"images\t_pipe.png");
        
        ground.Name = "ground";
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
        Controls.Add(ground);
        Controls.Add(bird);

        foreach (var pipe in pipes)
            Controls.Add(pipe);

        KeyDown += new KeyEventHandler(onKeyDown);
        KeyUp += new KeyEventHandler(onKeyUp);

        foreach (var pipe in pipes)
            EndInit(ref pipe);

        EndInit(ref bird);
        EndInit(ref ground);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private void BeginInit(ref Control control) =>
        ((System.ComponentModel.ISupportInitialize)(control)).BeginInit();
    private void EndInit(ref Control control) =>
        ((System.ComponentModel.ISupportInitialize)(control)).EndInit();
}
