using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_of_wrath.UI.AddOn
{
    internal class Blink
    {
        private Text text;
        private int blinkCounter = 0;

        public Blink(Text text)
        {
            this.text = text;
        }
        public void Update()
        {
            if (blinkCounter < 100)
            {
                if (blinkCounter > 25 && blinkCounter < 75)
                {
                    if (blinkCounter > 30 && blinkCounter < 65)
                    {
                        text.setOpacity(1f);
                    }
                    else
                    {
                        text.setOpacity(0.7f);
                    }
                }
                else
                {
                    text.setOpacity(0.3f);
                }
                blinkCounter++;
            }
            else
            {
                blinkCounter = 0;
            }
        }
    }
}
