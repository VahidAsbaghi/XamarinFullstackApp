using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Zave.Torbat.Siman.Co.Core.Models;
using Object = Java.Lang.Object;

namespace Zave.Torbat.Siman.Android.Adapters
{
    public class TakeLoadListAdapter:BaseAdapter<Load>
    {
        private readonly Activity _viewContext;
        private readonly List<Load> _loads;

        public TakeLoadListAdapter(Activity viewContext,List<Load> loads)
        {
            _viewContext = viewContext;
            _loads = loads;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var load = _loads[position];
            if (convertView==null)
            {
                convertView = _viewContext.LayoutInflater.Inflate(Resource.Layout.LoadRowItemLayout, null);
            }

            //convertView.FindViewById<EditText>(Resource.Id.txtLoadType).Text=load.Type;
            //convertView.FindViewById<EditText>(Resource.Id.txtCustomerName).Text = load.CustomerName;
            var txtLoadWeight= convertView.FindViewById<TextView>(Resource.Id.txtLoadWeight);
            var txtDestinationAddress = convertView.FindViewById<TextView>(Resource.Id.txtDestinationAddress);
            var txtObjectName = convertView.FindViewById<TextView>(Resource.Id.txtObjectName);
            txtLoadWeight.Text = load.Amount.ToString();
            txtDestinationAddress.Text = load.HandOverAddress;
            txtObjectName.Text = load.TransportationType;
            var imageView=convertView.FindViewById<ImageView>(Resource.Id.imageType);
            if (load.Product=="کلینکر")
            {
                imageView.SetImageBitmap(BitmapFactory.DecodeResource(_viewContext.Resources, Resource.Drawable.clinker));
            }
            else if(load.Product=="بیگ بگ")
            {
                imageView.SetImageBitmap(BitmapFactory.DecodeResource(_viewContext.Resources, Resource.Drawable.bigPacket));
            }
            else if(load.Product=="پاکتی")
            {
                imageView.SetImageBitmap(BitmapFactory.DecodeResource(_viewContext.Resources, Resource.Drawable.packet));
            }
            else if (load.Product == "فله")
            {
                imageView.SetImageBitmap(BitmapFactory.DecodeResource(_viewContext.Resources, Resource.Drawable.falleh));
            }
            return convertView;
        }

        public override int Count => _loads.Count;

        public override Load this[int position] => _loads[position];
    }
}