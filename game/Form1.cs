namespace game;

public partial class MainWindow : Form
{
    private int pipeSpeed = 5;
    private int gravity = 5;
    private int score = 0;

    public MainWindow()
    {
        InitializeComponent();
        gameTimer.Start();
    }

    private void gameTimer_Tick(object sender, EventArgs e)
    {
        bird.Top += gravity;
        foreach (var pipe in pipes)
            pipe.Left -= pipeSpeed;

        scoreText.Text = score.ToString();

        // if(bottomPipe.Left < -150 )
        // {
        //     bottomPipe.Left = 950;
        //     score++;
        // }

        // if (topPipe.Left < -180)
        // {
        //     topPipe.Left = 950;
        //     score++;
        // }

        // if (bird.Bounds.IntersectsWith(bottomPipe.Bounds) ||
        //     bird.Bounds.IntersectsWith(topPipe.Bounds) ||
        //     bird.Bounds.IntersectsWith(ground.Bounds) || bird.Top < -25)
        // {
        //     if (score > 0) score--;
        //     else gameOver();
        // }

        // if (score > 10) pipeSpeed = 10;
    }

    private void onKeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space) gravity = 5;
    }

    private void onKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space) gravity = -5;
        if (e.KeyCode == Keys.R) restart();
    }

    private void gameOver()
    {
        gameTimer.Stop();
        scoreLabel.Text = "Oops! Game Over";
    }

    private void restart()
    {
        scoreLabel.Text = "Jopa";
    }
}
