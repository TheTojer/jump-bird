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

    Random random = new Random();
    int r = 0;

    private void InitializeComponent()
    {
        components = new Container();
        bird = new PictureBox();

        pipes = new PictureBox[4];

        ground = new PictureBox();
        scoreLabel = new Label();
        scoreText = new Label();
        gameTimer = new Timer(components);

        for (int i = 0; i < pipes.Length; i++)
            pipes[i] = new PictureBox();

        for (int i = 0; i < pipes.Length; i++)
            ((System.ComponentModel.ISupportInitialize)(pipes[i])).BeginInit();

        ((System.ComponentModel.ISupportInitialize)(bird)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(ground)).BeginInit();

        SuspendLayout();
        
        bird.Name = "bird";
        bird.TabStop = false;

        bird.BackColor = Color.Transparent;
        if (File.Exists(@"images\bird.png"))
            bird.Image = Image.FromFile(@"images\bird.png");

        bird.Location = new Point(25, 226);
        bird.Size = new Size(100, 75);
        bird.SizeMode = PictureBoxSizeMode.StretchImage;
        
        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].Name = i % 2 == 0 ? "bottomPipe" : "topPipe" + i;
            pipes[i].TabStop = false;
            pipes[i].BackColor = Color.Transparent;
            pipes[i].Size = new Size(150, 700);
            pipes[i].SizeMode = PictureBoxSizeMode.StretchImage;
        }

        SetPipesLocation();

        if (File.Exists(@"images\b_pipe.png"))
            for (int i = 0; i < pipes.Length; i += 2)
                pipes[i].Image = Image.FromFile(@"images\b_pipe.png");

        if (File.Exists(@"images\t_pipe.png"))
            for (int i = 1; i < pipes.Length; i += 2)
                pipes[i].Image = Image.FromFile(@"images\t_pipe.png");
        
        ground.Name = "ground";
        ground.TabStop = false;

        ground.BackColor = Color.Transparent;
        if (File.Exists(@"images\ground.png"))
            ground.Image = Image.FromFile(@"images\ground.png");

        ground.Location = new Point(0, 700);
        ground.Size = new Size(1200, 200);
        ground.SizeMode = PictureBoxSizeMode.StretchImage;

        scoreLabel.Name = "scoreLabel";
        scoreLabel.Text = "Счет:";
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
        ClientSize = new Size(1200, 900);

        BackColor = Color.LightSkyBlue;
        BackgroundImageLayout = ImageLayout.Stretch;
        ForeColor = Color.Cornsilk;

        Controls.Add(scoreText);
        Controls.Add(scoreLabel);
        Controls.Add(ground);
        Controls.Add(bird);

        foreach (var pipe in pipes)
            Controls.Add(pipe);

        KeyDown += new KeyEventHandler(MainWindow_OnKeyDown);
        KeyUp += new KeyEventHandler(MainWindow_OnKeyUp);
        SizeChanged += new EventHandler(MainWindow_OnSizeChanged);

        for (int i = 0; i < pipes.Length; i++)
            ((System.ComponentModel.ISupportInitialize)(pipes[i])).EndInit();

        ((System.ComponentModel.ISupportInitialize)(bird)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(ground)).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private void MainWindow_OnSizeChanged(object sender, EventArgs e)
    {
        ground.Size = new Size(Width, 200);
        ground.Location = new Point(0, Height - 200);
    }

    private void SetPipesLocation()
    {
        for (int i = 0; i < pipes.Length; i++)
        {
            if (i % 2 == 0)
                r = random.Next(1, 7);
            pipes[i].Location = new Point(700 + (int)(i / 2) * 1000, i % 2 == 0 ? 100 + 100 * r : -800 + 100 * r);
        }
    }
}
