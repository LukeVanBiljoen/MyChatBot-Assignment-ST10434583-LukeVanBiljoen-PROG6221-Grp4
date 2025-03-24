//----------------------------------------------------------------Start of File-------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using MyChatBot_ST10434583_LukeVanBiljoen_PROG6221_Grp4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MyChatBot_ST10434583_LukeVanBiljoen_PROG6221_Grp4.WorkerClass;

namespace MyChatBot_ST10434583_LukeVanBiljoen_PROG6221_Grp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------------------------------------------------------------------------------------------------------------------//

            /// <summary>
            /// Creates an instance to start the chatbot program.
            /// </summary>

            ConsoleChatBot chatbot = new ConsoleChatBot();
            chatbot.Start();

            //----------------------------------------------------------------------------------------------------------------------//

            /// <summary>
            /// Still in progress with the extended version dont run.
            /// </summary>

            //ChatBotExtended chatBoxExtended = new ChatBotExtended();
            //chatBoxExtended.Start();

        }
    }
}

//----------------------------------------------------------------End of File-------------------------------------------------------------------//
