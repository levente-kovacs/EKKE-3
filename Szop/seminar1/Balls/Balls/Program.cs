internal class Program
{
    public static ManualResetEvent mre = new ManualResetEvent(false);
    public static ManualResetEvent _shutdownEvent = new ManualResetEvent(false);

    private static void Main(string[] args)
    {
        Balls b1 = new Balls(10, 10, -1, +1);
        Balls b2 = new Balls(50, 10, +1, +1);
        Balls b3 = new Balls(10, 20, +1, -1);


        Thread t1 = new Thread(b1.Move);
        Thread t2 = new Thread(b2.Move);
        Thread t3 = new Thread(b3.Move);
        t1.Start(); t2.Start();t3.Start();
       // mre.Set();
        Console.ReadLine();
        mre.Set();
        Console.ReadLine();
        _shutdownEvent.Set();


    }
}

class Balls
{
    public int CurrentPosX;
    public int CurrentPosY;
    public int DirectionX;
    public int DirectionY;

    public Balls(int cx, int cy, int dx, int dy)
    {
        this.CurrentPosX = cx;
        this.CurrentPosY = cy;
        this.DirectionX = dx;
        this.DirectionY = dy;
    }

    public void Move()
    {
        
        while (true)
        {
            Program.mre.WaitOne();
            if (Program._shutdownEvent.WaitOne(0))
                 break;
            
            lock (typeof(Program))
            {
                Console.SetCursorPosition(this.CurrentPosX, this.CurrentPosY);
                Console.Write(' ');
            }
            if (CurrentPosX >0 || CurrentPosX < 80)
                this.CurrentPosX += this.DirectionX;
            if(CurrentPosY >0 || CurrentPosY <25)
                this.CurrentPosY += this.DirectionY;
            if (CurrentPosX == 0 || CurrentPosX == 80)
            {
                this.DirectionX *= -1;
                this.CurrentPosX += this.DirectionX;
            }
            if (CurrentPosY == 0 || CurrentPosY == 25)
            {
                this.DirectionY *= -1;
                this.CurrentPosY += this.DirectionY;
            }
            lock (typeof(Program))
            {
                Console.SetCursorPosition(this.CurrentPosX, this.CurrentPosY);
                Console.Write('O');
            }
            Thread.Sleep(200);
        }
       
        
       
    }

}