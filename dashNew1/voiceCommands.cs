using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace dashNew1
{
    class voiceCommands
    {
        SpeechRecognitionEngine recEngin = new SpeechRecognitionEngine();
        public void startVoice()
        {
            recEngin.RecognizeAsync(RecognizeMode.Multiple);
        }
        public void stopVoice()
        {
            recEngin.RecognizeAsyncStop();
        }
        public void RecEngin_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "goto add vehicle":
                    Add_vehicle obj = new Add_vehicle();
                    obj.Show();
                    break;
                case "goto view vehicle":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto update vehicle":
                    Updt_vehicle obj2 = new Updt_vehicle();
                    obj2.Show();
                    break;
                case "goto book vehicle":
                    Booking obj3 = new Booking();
                    obj3.Show();
                    break;
                case "goto add customer":
                    addCustomer obj4 = new addCustomer();
                    obj4.Show();
                    break;
              /*  case "goto view customer":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto update customer":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto view bookings":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto add driver":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto view driver":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto update driver":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto add service":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto view service":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto update service":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto serivce report":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto add repairs":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto view repairs":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto update repairs":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto maintenance report":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto accident report":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto add insurance":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto view insurance":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto update insurance":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto add owner":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto view owner":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;
                case "goto update owner":
                    Update_Vehicle obj1 = new Update_Vehicle();
                    obj1.Show();
                    break;*/

            }
        }

        public void loadCommands()
        {
            Choices command = new Choices();
            command.Add(new string[] { "goto add vehicle", "goto view vehicle", "goto update vehicle", "goto book vehicle", "goto add customer" });
            GrammarBuilder gbiulder = new GrammarBuilder();
            gbiulder.Append(command);
            Grammar grammar = new Grammar(gbiulder);


            recEngin.LoadGrammarAsync(grammar);
            recEngin.SetInputToDefaultAudioDevice();
            recEngin.SpeechRecognized += RecEngin_SpeechRecognized;
        }


    }
}
