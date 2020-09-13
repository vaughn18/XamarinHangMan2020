using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Org.Apache.Http.Conn;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static Android.App.ActionBar;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace XamarinHangMan2020
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Operations operation = new Operations();

        //db variables
        Database db;
        List<Leaderboard> listSource = new List<Leaderboard>();
        ListView listViewData;


        //fundamental variables
        private Button btnPlay;
        private Button btnLeaderboard;
        private TextView errorMsg;
        private EditText form;
        private TextView tvWord;

        //leaderboard variables
        private TextView tvName;
        private TextView tvScore;

        private AlertDialog.Builder alertDialog;

        //keyboard
        private Button btnA;
        private Button btnB;
        private Button btnC;
        private Button btnD;
        private Button btnE;
        private Button btnF;
        private Button btnG;
        private Button btnH;
        private Button btnI;
        private Button btnJ;
        private Button btnK;
        private Button btnL;
        private Button btnM;
        private Button btnN;
        private Button btnO;
        private Button btnP;
        private Button btnQ;
        private Button btnR;
        private Button btnS;
        private Button btnT;
        private Button btnU;
        private Button btnV;
        private Button btnW;
        private Button btnX;
        private Button btnY;
        private Button btnZ;

        //word to guess
        private string gameWord;

        //image
        ImageView imgHangMan;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            RestartGame();
        }

        private void RestartGame()
        {
            SetContentView(Resource.Layout.activity_main);
            MenuInit();
            errorMsg.Text = "";
            btnPlay.Click += btnPlay_Click;
        }

        //button play function. Also checks form
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (operation.FormCheck(form.Text))
            {
                errorMsg.Text = "";
                SetContentView(Resource.Layout.game_main);
                initGameScreen();

            }
            else
            {
                errorMsg.Text = "Please Enter your name";
            }
        }

        //initialise buttons and whatever is in the game screen
        private void initGameScreen()
        {
            SetContentView(Resource.Layout.game_main);
            //initialise btn array
            Button[] btnArr = new Button[] {
               btnA = FindViewById<Button>(Resource.Id.btnA),
               btnB= FindViewById<Button>(Resource.Id.btnB),
               btnC= FindViewById<Button>(Resource.Id.btnC),
               btnD= FindViewById<Button>(Resource.Id.btnD),
               btnE= FindViewById<Button>(Resource.Id.btnE),
               btnF= FindViewById<Button>(Resource.Id.btnF),
               btnG= FindViewById<Button>(Resource.Id.btnG),
               btnH= FindViewById<Button>(Resource.Id.btnH),
               btnI= FindViewById<Button>(Resource.Id.btnI),
               btnJ= FindViewById<Button>(Resource.Id.btnJ),
               btnK= FindViewById<Button>(Resource.Id.btnK),
               btnL= FindViewById<Button>(Resource.Id.btnL),
               btnM= FindViewById<Button>(Resource.Id.btnM),
               btnN= FindViewById<Button>(Resource.Id.btnN),
               btnO= FindViewById<Button>(Resource.Id.btnO),
               btnP= FindViewById<Button>(Resource.Id.btnP),
               btnQ= FindViewById<Button>(Resource.Id.btnQ),
               btnR= FindViewById<Button>(Resource.Id.btnR),
               btnS= FindViewById<Button>(Resource.Id.btnS),
               btnT= FindViewById<Button>(Resource.Id.btnT),
               btnU= FindViewById<Button>(Resource.Id.btnU),
               btnV= FindViewById<Button>(Resource.Id.btnV),
               btnW= FindViewById<Button>(Resource.Id.btnW),
               btnX= FindViewById<Button>(Resource.Id.btnX),
               btnY= FindViewById<Button>(Resource.Id.btnY),
               btnZ= FindViewById<Button>(Resource.Id.btnZ),
            };
            //assign buttons to a method
            foreach (Button btn in btnArr) {
                btn.Click += ButtonClick;
            }

            //initialise word to guess
            gameWord = operation.ChooseWord("animal");
            tvWord = FindViewById<TextView>(Resource.Id.tvWord);
            tvWord.Text = gameWord;

            //init image
            imgHangMan = FindViewById<ImageView>(Resource.Id.imgHangMan);
            imgHangMan.SetImageResource(Resource.Drawable.first);

        }

        //function when keyboard is clicked
        private void ButtonClick(object sender, EventArgs e)
        {
            //the current button being pressed
            Button currentButton = (Button)sender;
            //play the game
            tvWord.Text = operation.GamePlay(currentButton.Text);
            if (tvWord.Text == "win")
            {
                alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetCancelable(false);
                alertDialog.SetTitle("HangMan:");
                alertDialog.SetMessage(operation.winMessage());
                alertDialog.SetNeutralButton("Next Word", delegate
                {
                    //next round
                    alertDialog.Dispose();
                    operation.RestartGame();
                    initGameScreen();


                });
                alertDialog.Show();
            }

            //disable button
            currentButton.Enabled = false;        
            //get how many tries the user has left to play
            switch(operation.getTries())
            {
                case 0:
                    imgHangMan.SetImageResource(Resource.Drawable.first);
                    break;
                case 1:
                    imgHangMan.SetImageResource(Resource.Drawable.second);
                    break;
                case 2:
                    imgHangMan.SetImageResource(Resource.Drawable.third);
                    break;
                case 3:
                    imgHangMan.SetImageResource(Resource.Drawable.fourth);
                    break;
                case 4:
                    imgHangMan.SetImageResource(Resource.Drawable.fifth);
                    break;
                case 5:
                    imgHangMan.SetImageResource(Resource.Drawable.sixth);
                    break;
                case 6:
                    imgHangMan.SetImageResource(Resource.Drawable.seventh);
                    break;
                case 7:
                    imgHangMan.SetImageResource(Resource.Drawable.eigth);
                    break;
                case 8:
                    imgHangMan.SetImageResource(Resource.Drawable.ninth);
                    break;
                case 9:
                    imgHangMan.SetImageResource(Resource.Drawable.lose);
                    alertDialog = new AlertDialog.Builder(this);
                    alertDialog.SetCancelable(false);
                    alertDialog.SetTitle("HangMan:");
                    alertDialog.SetMessage("You have lost the game");
                    alertDialog.SetNeutralButton("Restart", delegate
                    {
                        alertDialog.Dispose();
                        operation.RestartGame();
                        RestartGame();

                    });
                    alertDialog.Show();
                    break;
            }
        }

        //initialize buttons
        private void MenuInit()
        {
            //initialise play button
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            //initialise error message 
            errorMsg = FindViewById<TextView>(Resource.Id.tvErrorMsg);
            //initialise form field
            form = FindViewById<EditText>(Resource.Id.form);
            //initialise leader board button
            btnLeaderboard = FindViewById<Button>(Resource.Id.btnLeaderboard);
            btnLeaderboard.Click += Leaderboard_Click;
        }

        //load leaderboard
        private void Leaderboard_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.leaderboard_main);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.tbLeaderboard);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Leaderboards";

            //load database
            db = new Database();
            db.CreateDatabase();
            tvScore = FindViewById<TextView>(Resource.Id.tvScore);
            tvName = FindViewById<TextView>(Resource.Id.tvName);

        }

        //load leaderboard data
        private void LoadData()
        {
            listSource = db.selectTable();
            var adapter = new ListView()

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbar_menu, menu);
            return base.OnCreateOptionsMenu(menu);  
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            RestartGame();
            return base.OnOptionsItemSelected(item);    
        }
    }
}




