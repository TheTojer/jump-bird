namespace game;

public partial class MainWindow : Form
{
    private int pipeSpeed = 5;
    private int gravity = 5;
    private int score = 0;
    private int mainPipe = 0;

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

        if(pipes[mainPipe * 2].Left < -180 )
        {
            r = random.Next(1, 7);
            pipes[mainPipe * 2 + 1].Location = new Point(1700, -800 + 100 * r);
            pipes[mainPipe * 2].Location = new Point(1700, 100 + 100 * r);
            Console.WriteLine(pipes[mainPipe * 2].Left);
            mainPipe = (mainPipe + 1) % 2;
            score++;
        }

        if
        (
            bird.Bounds.IntersectsWith(pipes[mainPipe * 2].Bounds) ||
            bird.Bounds.IntersectsWith(pipes[mainPipe * 2 + 1].Bounds) ||
            bird.Bounds.IntersectsWith(ground.Bounds) || bird.Top < -25
        )
            GameOver();

        if (score > 10) pipeSpeed = 10;
    }

    private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space) gravity = 5;
    }

    private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space) gravity = -5;
        if (e.KeyCode == Keys.R) Restart();
    }

    private void GameOver()
    {
        gameTimer.Stop();
        scoreLabel.Text = "Игра окончена!";
        scoreText.Text = "Ваш счет: " + scoreText.Text;
    }

    private void Restart()
    {
        bird.Location = new Point(25, 226);
        SetPipesLocation();
        scoreText.Text = "0";
        scoreLabel.Text = "Счет:";
        score = 0;
        gravity = 5;
        mainPipe = 0;
        gameTimer.Start();
    }
}
