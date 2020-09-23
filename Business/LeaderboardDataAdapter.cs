using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Security;

namespace XamarinHangMan2020.Business
{
    public class LeaderboardDataAdapter : BaseAdapter<TableLeaderboard>
    {
        private readonly Activity context;
        private readonly List<TableLeaderboard> items;
        public LeaderboardDataAdapter(Activity context, List<TableLeaderboard> items)
        {
            this.context = context;
            this.items = items;

        }

        public override TableLeaderboard this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.leaderboardData, null);
                view.FindViewById<TextView>(Resource.Id.tvName).Text = $@"{item.Name}";
                view.FindViewById<TextView>(Resource.Id.tvScore).Text = $@"{item.Score}";
            }

            return view;
        }

    }
}   