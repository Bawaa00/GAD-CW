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
                case "goto view customer":
                    view_customer obj5 = new view_customer();
                    obj5.Show();
                    break;
                case "goto update customer":
                   update_customer obj6 = new update_customer();
                    obj6.Show();
                    break;
                case "goto view bookings":
                    view_bookings obj7 = new view_bookings();
                    obj7.Show();
                    break;
                case "goto add driver":
                    add_driver obj8 = new add_driver();
                    obj8.Show();
                    break;
                case "goto view driver":
                    view_driver obj9 = new view_driver();
                    obj9.Show();
                    break;
                case "goto update driver":
                    Driver obj10 = new Driver();
                    obj10.Show();
                    break;
                case "goto add service":
                    Services obj11 = new Services();
                    obj11.Show();
                    break;
                case "goto view service":
                    view_services obj12 = new view_services();
                    obj12.Show();
                    break;
                case "goto update service":
                    update_service obj13 = new update_service();
                    obj13.Show();
                    break;
                case "goto serivce report":
                    ServiceReport obj14 = new ServiceReport();
                    obj14.Show();
                    break;
                case "goto add repairs":
                    add_repairs obj15 = new add_repairs();
                    obj15.Show();
                    break;
                case "goto view repairs":
                    repairs obj16  = new repairs();
                    obj16.Show();
                    break;
                case "goto update repairs":
                    update_repair obj17 = new update_repair();
                    obj17.Show();
                    break;
                case "goto maintenance report":
                    MaintenanceReport obj18 = new MaintenanceReport();
                    obj18.Show();
                    break;
                case "goto accident report":
                    AccidentReport obj19 = new AccidentReport();
                    obj19.Show();
                    break;
                case "goto add insurance":
                    Add_Insurnce obj20 = new Add_Insurnce();
                    obj20.Show();
                    break;
                case "goto view insurance":
                    View_insurnce obj21 = new View_insurnce();
                    obj21.Show();
                    break;
                case "goto add owner":
                    Add_owner obj23 = new Add_owner();
                    obj23.Show();
                    break;
                case "goto view owner":
                    Owner_info obj24 = new Owner_info();
                    obj24.Show();
                    break;
                case "goto update owner":
                    Update_ownr obj25 = new Update_ownr();
                    obj25.Show();
                    break;

            }
        }

        public void loadCommands()
        {
            Choices command = new Choices();
            command.Add(new string[] { "goto add vehicle", "goto view vehicle", "goto update vehicle", "goto book vehicle", "goto add customer" , "goto view customer" , 
                "goto update customer" , "goto view bookings", "goto add driver", "goto view driver", "goto update driver", "goto add service", "goto view service", 
                "goto update service", "goto serivce report", "goto add repairs", "goto view repairs", "goto update repairs", "goto maintenance report", "goto accident report",
                "goto add insurance", "goto view insurance", "goto add owner", "goto view owner", "goto update owner" });
            GrammarBuilder gbiulder = new GrammarBuilder();
            gbiulder.Append(command);
            Grammar grammar = new Grammar(gbiulder);


            recEngin.LoadGrammarAsync(grammar);
            recEngin.SetInputToDefaultAudioDevice();
            recEngin.SpeechRecognized += RecEngin_SpeechRecognized;
        }


    }
}
