using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using static Android.App.ActionBar;

namespace XamarinHangMan2020
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Operations operation = new Operations();

        private Button btnPlay;
        private TextView errorMsg;
        private EditText form;
        private TextView tvWord;

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
            btnA = FindViewById<Button>(Resource.Id.btnA);
            btnB = FindViewById<Button>(Resource.Id.btnB);
            btnC = FindViewById<Button>(Resource.Id.btnC);
            btnD = FindViewById<Button>(Resource.Id.btnD);
            btnE = FindViewById<Button>(Resource.Id.btnE);
            btnF = FindViewById<Button>(Resource.Id.btnF);
            btnG = FindViewById<Button>(Resource.Id.btnG);
            btnH = FindViewById<Button>(Resource.Id.btnH);
            btnI = FindViewById<Button>(Resource.Id.btnI);
            btnJ = FindViewById<Button>(Resource.Id.btnJ);
            btnK = FindViewById<Button>(Resource.Id.btnK);
            btnL = FindViewById<Button>(Resource.Id.btnL);
            btnM = FindViewById<Button>(Resource.Id.btnM);
            btnN = FindViewById<Button>(Resource.Id.btnN);
            btnO = FindViewById<Button>(Resource.Id.btnO);
            btnP = FindViewById<Button>(Resource.Id.btnP);
            btnQ = FindViewById<Button>(Resource.Id.btnQ);
            btnR = FindViewById<Button>(Resource.Id.btnR);
            btnS = FindViewById<Button>(Resource.Id.btnS);
            btnT = FindViewById<Button>(Resource.Id.btnT);
            btnU = FindViewById<Button>(Resource.Id.btnU);
            btnV = FindViewById<Button>(Resource.Id.btnV);
            btnW = FindViewById<Button>(Resource.Id.btnW);
            btnX = FindViewById<Button>(Resource.Id.btnX);
            btnY = FindViewById<Button>(Resource.Id.btnY);
            btnZ = FindViewById<Button>(Resource.Id.btnZ);
            //initialise btn array
            Button[] btnArr = new Button[] {
               btnA,
               btnB,
               btnC,
               btnD,
               btnE,
               btnF,
               btnG,
               btnH,
               btnI,
               btnJ,
               btnK,
               btnL,
               btnM,
               btnN,
               btnO,
               btnP,
               btnQ,
               btnR,
               btnS,
               btnT,
               btnU,
               btnV,
               btnW,
               btnX,
               btnY,
               btnZ,
            };
            //assign buttons to a method
            foreach(Button btn in btnArr) {
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
            //disable button
            currentButton.Enabled = false;        
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

        }
    }
}




