//----------------------------------------------------------------Start of File-------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MyChatBot_ST10434583_LukeVanBiljoen_PROG6221_Grp4;

namespace MyChatBot_ST10434583_LukeVanBiljoen_PROG6221_Grp4.WorkerClass
{
    //---------------------------------------------------------------------------------------------//
    /// <summary>
    /// Declaring private variables.
    /// </summary>
    class ConsoleChatBot
    {
        private string userName;
        private Dictionary<string, List<string>> responses;
        private List<string> conversationHistory;
        private Random random;
        private int securityScore; // A 0-100 scale to track the user's cybersecurity awareness

        //---------------------------------------------------------------------------------------------//
        /// <summary>
        /// Initializes the chatbot with a random number generator,
        /// conversation history, and a starting security score.
        /// </summary>
        public ConsoleChatBot()
        {
            random = new Random();
            conversationHistory = new List<string>();
            securityScore = 50; //Starts with neutral score
            InitializeResponses();
        }

        //---------------------------------------------------------------------------------------------//
        /// <summary>
        /// Initializes the predefined responses for different topics and commands.
        /// </summary>
        private void InitializeResponses()
        {
            responses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                // Basic responses
                { "hello", new List<string> { "Hello there! Ready to learn about cybersecurity?", "Hi! How can I help you stay safe online today?", "Greetings! Let's talk about protecting yourself in the digital world." } },
                { "how are you", new List<string> { "I'm doing well, ready to help you with cybersecurity questions!", "I'm great! Eager to share online safety tips with you.", "All systems secure and operational! How can I assist you?" } },
                { "name", new List<string> { "My name is CyberGuard, your cybersecurity awareness assistant.", "I'm CyberGuard! I'm here to help you stay safe online.", "They call me CyberGuard, your digital safety companion." } },
                { "help", new List<string> { "I can help with various cybersecurity topics. Try asking about phishing, passwords, or safe browsing.", "Need assistance? I can provide information about online scams, data protection, or general cybersecurity advice.", "I'm here to help! Ask me about protecting your digital identity, recognizing scams, or securing your devices." } },
                { "bye", new List<string> { "Goodbye! Stay safe online!", "See you later! Remember to keep your passwords strong and unique!", "Bye for now! Don't forget to think before you click on links." } },
                { "thanks", new List<string> { "You're welcome! Cybersecurity is everyone's responsibility.", "Happy to help keep you safe online!", "Anytime! The more you know about cybersecurity, the safer you'll be." } },
                
                // Cybersecurity topics
                { "phishing", new List<string> {
                    "Phishing is when attackers send fake emails pretending to be legitimate organizations to steal your information. Always check the sender's email address and don't click suspicious links.",
                    "Be wary of unexpected emails asking for personal information. Legitimate organizations won't ask for passwords or account details via email.",
                    "To avoid phishing scams, hover over links before clicking to see the actual URL, and be suspicious of urgent requests or threats.",
                    "South African banks are frequently impersonated in phishing attempts. Remember that banks will never ask for your full password or PIN via email or SMS."
                }},
                { "password", new List<string> {
                    "Strong passwords should be at least 12 characters long with a mix of letters, numbers, and symbols. Avoid using personal information or common words.",
                    "Consider using a password manager to create and store unique passwords for each account. Never reuse passwords across different sites.",
                    "Remember to change your passwords regularly, especially for important accounts like banking and email. Enable two-factor authentication when available.",
                    "A good strategy is to use a passphrase - a sequence of random words that's easy for you to remember but hard for others to guess."
                }},
                { "browsing", new List<string> {
                    "For safe browsing, keep your browser and operating system updated. Look for 'https' and a padlock icon in the address bar when visiting websites.",
                    "Be careful when downloading files or clicking on pop-up windows. Use an ad-blocker and consider a VPN for additional protection.",
                    "Public Wi-Fi networks can be risky. Avoid accessing sensitive information like banking details when using public networks.",
                    "Consider using private browsing mode when using shared computers, and always log out of your accounts when finished."
                }},
                { "malware", new List<string> {
                    "Malware is malicious software designed to damage or gain unauthorized access to your system. Keep your antivirus software updated to protect against it.",
                    "Signs of malware include slow performance, unexpected pop-ups, and strange behavior from your device. Run regular scans to detect and remove threats.",
                    "To prevent malware, be careful what you download, avoid clicking on suspicious links, and keep your software updated.",
                    "In South Africa, malware is often distributed through fake job offers or business opportunities. Be extra cautious with unsolicited job emails."
                }},
                { "social engineering", new List<string> {
                    "Social engineering is when attackers manipulate people into revealing confidential information. Always verify the identity of anyone requesting sensitive data.",
                    "Be suspicious of unsolicited calls or messages asking for personal information, even if they appear to come from trusted sources.",
                    "Social engineers often create a sense of urgency or fear. Take your time to verify requests through official channels before sharing any information.",
                    "In South Africa, there's been an increase in WhatsApp scams where attackers impersonate friends or family members in need of urgent financial help."
                }},
                { "scam", new List<string> {
                    "Common online scams in South Africa include fake job offers, romance scams, and investment schemes promising high returns. If it sounds too good to be true, it probably is.",
                    "Be wary of unexpected winnings or inheritance notifications. Legitimate lotteries don't require payment to release winnings.",
                    "Never send money or banking details to someone you've only met online. Research thoroughly before making any investments.",
                    "419 scams (advance-fee scams) are common in South Africa. These typically involve promises of a share in a large sum of money in exchange for a small upfront payment."
                }},
                { "ransomware", new List<string> {
                    "Ransomware is malware that encrypts your files and demands payment for their release. Regular backups are your best defense against ransomware attacks.",
                    "Never pay the ransom - it doesn't guarantee you'll get your files back and encourages more attacks.",
                    "Keep your operating system and software updated to protect against known vulnerabilities that ransomware exploits.",
                    "South African businesses have increasingly been targeted by ransomware. Ensure your organization has a response plan in place."
                }},
                { "identity theft", new List<string> {
                    "Identity theft occurs when someone uses your personal information without permission. Regularly check your bank statements and credit reports for suspicious activity.",
                    "Be careful about sharing personal information online, especially on social media. Adjust your privacy settings to limit who can see your information.",
                    "Shred documents containing personal information before disposing of them to prevent dumpster diving.",
                    "If you suspect your identity has been stolen, report it to the South African Fraud Prevention Service (SAFPS) immediately."
                }},
                { "mobile security", new List<string> {
                    "Only download apps from official stores like Google Play or the Apple App Store. Check reviews and permissions before installing.",
                    "Keep your phone's operating system and apps updated to protect against security vulnerabilities.",
                    "Use a PIN, password, or biometric authentication to lock your phone. Enable remote tracking and wiping features in case your phone is lost or stolen.",
                    "Be cautious with SMS banking in South Africa. Verify any SMS claiming to be from your bank through official channels before taking action."
                }},
                
                // Special commands
                { "security tips", new List<string> {
                    "Here are some essential cybersecurity tips:\n- Use unique, strong passwords for each of your accounts.\n- Enable two-factor authentication whenever possible.\n- Be cautious of unexpected emails, especially those with urgent requests.\n- Keep your software and operating systems updated.\n- Back up your important data regularly."
                }},
                { "quiz", new List<string> {
                    "Let's test your cybersecurity knowledge with a quick quiz:\n\nQuestion: What should you do if you receive an unexpected email from your bank asking for your password?\n\nA) Reply with your password\nB) Click on any links in the email\nC) Contact your bank directly using their official contact information\nD) Forward the email to friends to see if it's legitimate"
                }},
                
                // Default responses
                { "default", new List<string> {
                    "I'm not sure I understand that cybersecurity query. Could you rephrase or ask about phishing, passwords, safe browsing, or malware?",
                    "That's an interesting question! Could you provide more details so I can give you specific cybersecurity advice?",
                    "I'm still learning about that cybersecurity topic. Can you ask something about online scams, data protection, or secure browsing?"
                }}

            };

        }

        //---------------------------------------------------------------------------------------------//
        /// <summary>
        /// Starts the chatbot by displaying the welcome message, greeting the user, and prompting for their name.
        /// Begins the conversation loop.
        /// </summary>
        public void Start()
        {
            DisplayWelcomeMessage();
            PlayVoiceGreeting();
            GetUserName();
            Conversation();
        }

        //---------------------------------------------------------------------------------------------//
        /// <summary>
        /// Plays a voice greeting.
        /// </summary>
        private void PlayVoiceGreeting()
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(Properties.Resources.greeting))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions gracefully
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n[Voice greeting unavailable: {ex.Message}]");
                Console.ResetColor();
                Thread.Sleep(2000);
            }
        }

        //---------------------------------------------------------------------------------------------//
        /// <summary>
        /// Displays the welcome message and introductory information to the user.
        /// </summary>
        private void DisplayWelcomeMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
    *                             |>>>                    +
+          *                      |                   *       +
                    |>>>      _  _|_  _   *     |>>>
           *        |        |;| |;| |;|        |                 *
     +          _  _|_  _    \\.    .  /    _  _|_  _       +                          
 *             |;|_|;|_|;|    \\: +   /    |;|_|;|_|;|
               \\..      /    ||:+++. |    \\.    .  /           *
      +         \\.  ,  /     ||:+++  |     \\:  .  /
                 ||:+  |_   _ ||_ . _ | _   _||:+  |       *
          *      ||+++.|||_|;|_|;|_|;|_|;|_|;||+++ |          +
                 ||+++ ||.    .     .      . ||+++.|   *
+   *            ||: . ||:.     . .   .  ,   ||:   |               *
         *       ||:   ||:  ,     +       .  ||: , |      +
  *              ||:   ||:.     +++++      . ||:   |         *
     +           ||:   ||.     +++++++  .    ||: . |    +
           +     ||: . ||: ,   +++++++ .  .  ||:   |             +
                 ||: . ||: ,   +++++++ .  .  ||:   |        *
*                ||: . ||: ,   +++++++ .  .  ||:   |
        _____      _               _____                     _   +
   +   / ____|    | |             / ____|                   | |    *          
      | |    _   _| |__   ___ _ _| |  __ _   _  __ _ _ __ __| |      +
*     | |   | | | | '_ \ / _ \ '__| | |_ | | | |/ _` | '__/ _` |     
      | |___| |_| | |_) |  __/ |  | |__| | |_| | (_| | | | (_| |   *
  +    \_____\__, |_.__/ \___|_|   \_____|\__,_|\__,_|_|  \__,_|     +                        
              __/ |                                             
             |___/                                              
");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=========================================================================");
            Console.WriteLine("  Welcome to Luke's CyberGuard - Your Cybersecurity Awareness Assistant  ");
            Console.WriteLine("=========================================================================");
            Console.ResetColor();

            Console.WriteLine("\nI'm here to help you learn about cybersecurity and stay safe online!");
            Thread.Sleep(1000); // Program pauses for 100 milliseconds or 1 second before continuing
        }

        //---------------------------------------------------------------------------------------------//
        /// <summary>
        /// Prompts the user for their name and validates the input.
        /// </summary>
        private void GetUserName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nBefore we start, may I know your name please? ");
            Console.ResetColor();

            string input = Console.ReadLine()?.Trim() ?? "";

            // Input validation
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("I didn't catch that. Please enter your name: ");
                Console.ResetColor();
                input = Console.ReadLine()?.Trim() ?? "";
            }

            userName = input;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nNice to meet you, {userName}! I'm here to help you learn about cybersecurity."); // Interpolate string for the userName input variable
            Console.WriteLine("(Type 'help' for suggestions, 'security tips' for quick advice, or 'bye' to exit)");
            Console.ResetColor();
        }

        //---------------------------------------------------------------------------------------------//
        /// <summary>
        /// Main conversation loop that continuously accepts user input and provides responses.
        /// </summary>
        private void Conversation()
        {
            bool conversationActive = true;

            while (conversationActive)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n> ");
                Console.ResetColor();

                string userInput = Console.ReadLine()?.Trim() ?? "";

                // Input validation
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("It seems you didn't type anything. Please try again.");
                    Console.ResetColor();
                    continue;
                }

                // Add to conversation history
                conversationHistory.Add($"You: {userInput}");

                // Check for exit command
                if (userInput.ToLower() == "bye" || userInput.ToLower() == "exit" || userInput.ToLower() == "quit")
                {
                    conversationActive = false;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\nGoodbye, {userName}! Remember to stay vigilant online. Stay safe!");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    continue;
                }

                // Process and respond to user input
                string response = GenerateResponse(userInput);

                // Add typing effect
                TypeResponse(response);

                // Add to conversation history
                conversationHistory.Add($"CyberGuard: {response}");
            }
        }
        //---------------------------------------------------------------------------------------------//
        /// <summary>
        /// Generates a response to the user's input, including handling special commands,
        /// personalizing responses, and checking for keywords related to cybersecurity topics.
        /// </summary>
        /// <param name="userInput">The user's input text.</param>
        /// <returns>A string response generated for the user.</returns>
        private string GenerateResponse(string userInput)
        {
            // Check for special commands
            if (userInput.ToLower() == "security tips")
            {
                return responses["security tips"][0];
            }

            if (userInput.ToLower() == "quiz")
            {
                return responses["quiz"][0];
            }

            if (userInput.ToLower() == "history")
            {
                return GetConversationHistory();
            }

            if (userInput.ToLower() == "clear")
            {
                Console.Clear();
                DisplayWelcomeMessage();
                return "Screen cleared!";
            }

            // Check for user's name in the input for personalization
            if (userInput.ToLower().Contains(userName.ToLower()))
            {
                return $"Yes, {userName}? How can I help you with cybersecurity today?";
            }

            // Find matching keywords in the input
            foreach (var entry in responses)
            {
                if (entry.Key != "default" && entry.Key != "security tips" && entry.Key != "quiz" &&
                    Regex.IsMatch(userInput, $"\\b{entry.Key}\\b", RegexOptions.IgnoreCase))
                {
                    string baseResponse = entry.Value[random.Next(entry.Value.Count)];

                    // Add personalization
                    if (random.Next(5) == 0) // 20% chance
                    {
                        baseResponse = $"{userName}, {baseResponse}";
                    }

                    return baseResponse;
                }
            }

            // If no keyword matches, return default response
            var defaultResponses = responses["default"];
            return defaultResponses[random.Next(defaultResponses.Count)];
        }

        //---------------------------------------------------------------------------------------------//
        /// <summary>
        /// Retrieves the recent conversation history of the user with the chatbot.
        /// Displays the last 5 messages in the conversation.
        /// </summary>
        /// <returns>A string representing the conversation history.</returns>
        private string GetConversationHistory()
        {
            if (conversationHistory.Count == 0)
                return "We haven't had much of a conversation yet.";

            return "Here's a summary of our recent conversation:\n" + string.Join("\n", conversationHistory.Take(5));
        }

        //---------------------------------------------------------------------------------------------//
        /// <summary>
        /// Simulates typing the response in the console with a delay between each character.
        /// Creates a typing effect to enhance user experience.
        /// </summary>
        /// <param name="response">The response text to type out.</param>
        private void TypeResponse(string response)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nCyberGuard: ");
            Console.ForegroundColor = ConsoleColor.White;

            // Simulate typing effect
            foreach (char c in response)
            {
                Console.Write(c);
                Thread.Sleep(20); // Adjust speed as needed
            }

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}

//----------------------------------------------------------------End of File-------------------------------------------------------------------//

