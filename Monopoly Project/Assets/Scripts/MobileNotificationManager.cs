using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class MobileNotificationManager : MonoBehaviour
    {
        public void SaveNotification()
        {
            var channel = new AndroidNotificationChannel()
            {
                Id = "channel_id",
                Name = "Default Channel",
                Importance = Importance.Default,
                Description = "Generic notifications",
            };
            AndroidNotificationCenter.RegisterNotificationChannel(channel);

            AndroidNotification notification = new AndroidNotification()
            {
                Title = "ถึงเวลาที่กำหนดแล้ว",
                Text = "สามารถเข้าเล่นเกมได้แล้วนะ",
                SmallIcon = "my_custom_icon_id",
                LargeIcon = "my_custom_large_icon_id",
                FireTime = System.DateTime.Today.AddMinutes(TimeSetting._totalMinuteTime),
            };
            var identifier = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        }
    }
}




