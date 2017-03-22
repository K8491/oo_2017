using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeWPF
{
    /// <summary>
    /// Classic old snake game using WPF
    /// </summary>
    /// 
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
    public partial class Game : Window
    {
        //variables and consts
        private const int minimi= 10;
        private const int maxHeight =380;
        private const int maxWidth = 620;
        private const int snakeWidth = 10;
        private int snakeLenght = 100;
        private int easiness = 50; //timerin ajastin aika
        private int score = 0;
        private List<Point> bonusPoints = new List<Point>(); //omena kokoelma
        private const int bonusCount = 20; //omenat
        private List<Point> snakeParts = new List<Point>();
        private Point startingPoint=new Point(100,100); 
        private Point currentPosition = new Point(); 
        private Direction lastDirection = Direction.Right; 
        private Direction currentDirection = Direction.Right;
        private DispatcherTimer timer;


        private Random rnd = new Random(); // pisteiden arvontaa varten


        public Game()
        {
            InitializeComponent();
            //alustukset
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,0,0,easiness);
            timer.Tick += new EventHandler(timer_Tick);
            // maaritellaan ikkunalle tapahtuman kasittelija nappaimiston kuuntelua varten
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);

            //piirretaan omenat ja kaarme
            IniBonusPoints();
            PaintSnake(startingPoint);
            currentPosition = startingPoint;

            //start game
            timer.Start(); //ikaan kuin loop
           
        }

        private void IniBonusPoints()
        {
            for (int n = 0; n < bonusCount; n++)
            {
                PaintBonus(n); // kutsuu Paintbonus..

            }
        }
        private void PaintSnake(Point currentpoint)
        {
            Ellipse snake = new Ellipse();
            snake.Fill = Brushes.Green;
            snake.Width = snakeWidth;
            snake.Height = snakeWidth;
            Canvas.SetTop(snake, currentpoint.Y);
            Canvas.SetLeft(snake, currentpoint.X);
            int count = paintCanvas.Children.Count;
            paintCanvas.Children.Add(snake);
            snakeParts.Add(currentPosition);
            //rajoitetaan käärmeen pituutta
            //huom! bonusCount < snakeLenght
            if (count > snakeLenght)
            {
                paintCanvas.Children.RemoveAt(count - snakeLenght + (bonusCount -1));
                snakeParts.RemoveAt(count - snakeLenght);

            }
        }
        private void PaintBonus(int index)
        {

             // arvotaan omenalle piste (X,Y)
            Point point = new Point(rnd.Next(minimi, maxWidth-10), rnd.Next(minimi, maxHeight-10));

            for (int i = 0; i < snakeParts.Count; i++)
            {
                do
            {      
                    new Point(rnd.Next(minimi, maxWidth-10), rnd.Next(minimi, maxHeight-10));
              
            } while ((Math.Abs (snakeParts[i].X - point.X) < 10 && (Math.Abs( snakeParts[i].Y - point.Y )< 10)));
                break;
            }

            //omenan piirto
            Ellipse omena = new Ellipse();
                omena.Fill = Brushes.Red;
                omena.Width = snakeWidth;
                omena.Height = snakeWidth;
                Canvas.SetTop(omena, point.Y);
                Canvas.SetLeft(omena, point.X);

            paintCanvas.Children.Insert(index, omena); //koska me lisätään listassa tiettyyn pisteeseen
            bonusPoints.Insert(index, point);


        }
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            // muutetaan suuntaa nappaimiston painalluksen mukaan
            // mutta ei sallita 180 asteen kaannosta
            switch (e.Key)
            {
                case Key.P:
                    if (timer.IsEnabled)
                        timer.Stop();
                    else
                        timer.Start();

                    break;
                case Key.Escape:
                    if (timer.IsEnabled)
                        GameOver();
                    else
                        this.Close();
                    break;

                case Key.Left:
                    if (lastDirection != Direction.Right)
                        currentDirection = Direction.Left;
                    break;

                case Key.Up :
                    if (lastDirection != Direction.Down)
                        currentDirection = Direction.Up;
                    break;

                case Key.Right:
                    if (lastDirection != Direction.Left)
                        currentDirection = Direction.Right;
                    break;
                case Key.Down:
                    if (lastDirection != Direction.Up)
                        currentDirection = Direction.Down;
                    break;
            }
            lastDirection = currentDirection;
        }
        private void timer_Tick(object sender, EventArgs e) // pakolliset tapahtuman kasittelijat, ei voi olla pelkka methodi
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    currentPosition.Y -= 4;
                    break;
                case Direction.Right:
                    currentPosition.X += 4;
                    break;
                case Direction.Down:
                    currentPosition.Y += 4;
                    break;
                case Direction.Left:
                    currentPosition.X -= 4;
                    break;
                default:
                    break;
            }
            PaintSnake(currentPosition);
            //tormaystarkastelut 1-3
            //TT#1 tarkistetaan onko canvaasilla
            if ((currentPosition.X > maxWidth) || (currentPosition.X < minimi) ||
                (currentPosition.Y > maxHeight) || (currentPosition.Y < minimi))
            GameOver();
            // TT#2 tarkistetaan ettei pure omaa hantaansa
            for (int i = 0; i < snakeParts.Count - snakeWidth * 2; i++)
            {
                Point p = new Point(snakeParts[i].X, snakeParts[i].Y);
                if ((Math.Abs(p.X - currentPosition.X) < snakeWidth) &&
                    (Math.Abs(p.Y - currentPosition.Y) < snakeWidth))
                {
                    GameOver();
                    break;
                }
            }
            //TT#3
            // tarkistetaan osuuko omenaan
                int n = 0;
            foreach (Point point in bonusPoints)
            {
                if ((Math.Abs(point.X - currentPosition.X) < snakeWidth) &&
                   (Math.Abs(point.Y - currentPosition.Y) < snakeWidth))
                {

                    // syodaan omena
                    score += 10;
                    snakeLenght += 10;

                    // nopeutetaan pelia
                    if(easiness > 5)
                    {
                        easiness--;
                        timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
                    }
                    else
                    {
                        snakeLenght += 5;
                        score += 10;
                    }
                    this.Title = "SnakeWPF Your score:" + score;
                    bonusPoints.RemoveAt(n);
                    paintCanvas.Children.RemoveAt(n);
                    PaintBonus(n);
                    break;
                }
                n++;
            }
        }
        private void GameOver()
        {
            timer.Stop();
            //MessageBox.Show("Your Score: " + score); 
            // this.Close(); // palaa startti ikkunaan
            GameOverShow();


        }
        private void GameOverShow()
        {
            txtMessage.Text = "Your score: " + score + " \n press Esc to quit";
            //animaatio joka siirtaa kanvaasin
            var trs = new TranslateTransform();
            var anim = new DoubleAnimation(0,620, TimeSpan.FromSeconds(15));
            trs.BeginAnimation(TranslateTransform.XProperty, anim);
            trs.BeginAnimation(TranslateTransform.YProperty, anim);
            paintCanvas.RenderTransform = trs;
        }

    }
}
