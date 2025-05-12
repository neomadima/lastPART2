using System;
using System.Collections.Generic;
using System.Threading;

class CyberSecurityChatBot
{
    static string userName = "User";
    static string favoriteTopic = "";
    static List<string> userInterests = new List<string>();
    static Random random = new Random();

    static void Main()
    {
        Console.Title = "🔐 CyberSecurity ChatBot ";
        Console.ForegroundColor = ConsoleColor.Cyan;
        DisplayAsciiArt();

        Console.Write("\n👤 Please enter your name: ");
        userName = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(userName))
        {
            userName = "User";
        }

        Console.Clear();
        WelcomeMessage();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n💬 Ask me something (or type 'exit' to quit): ");
            Console.ForegroundColor = ConsoleColor.White;
            string userInput = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(userInput))
            {
                DisplayResponse("⚠️ Please ask a valid question.");
                continue;
            }

            if (userInput == "exit")
            {
                DisplayResponse($"👋 Goodbye, {userName}! Stay safe online!");
                break;
            }

            ProcessUserInput(userInput);
        }
    }

    static void DisplayAsciiArt()
    {
        Console.WriteLine(@"
 ██████╗ ██╗   ██╗██████╗ ███████╗██████╗      ██████╗  ██████╗ ████████╗
██╔═══██╗██║   ██║██╔══██╗██╔════╝██╔══██╗     ██╔══██╗██╔═══██╗╚══██╔══╝
██║   ██║██║   ██║██████╔╝█████╗  ██████╔╝     ██████╔╝██║   ██║   ██║   
██║▄▄ ██║██║   ██║██╔═══╝ ██╔══╝  ██╔═══╝      ██╔═══╝ ██║   ██║   ██║   
╚██████╔╝╚██████╔╝██║     ███████╗██║          ██║     ╚██████╔╝   ██║   
 ╚══▀▀═╝  ╚═════╝ ╚═╝     ╚══════╝╚═╝          ╚═╝      ╚═════╝    ╚═╝   
");
        Console.WriteLine("🔹 Welcome to CyberSecurity ChatBot 🔹\n");
    }

    static void WelcomeMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"👋 Hello {userName}! Ready to explore cybersecurity together?");
        Thread.Sleep(500);
        Console.WriteLine("\n***********************");
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void ProcessUserInput(string input)
    {
        string mood = DetectCyberSecuritySentiment(input);

        if (input.Contains("worried") && input.Contains("scam"))
        {
            DisplayResponse($"💬 It's completely understandable to feel that way, {userName}! Scammers can be very convincing. 🛡️ Let me share some tips to help you stay safe:");
            ProvideScamSafetyTips();
            return;
        }

        AdjustMoodResponse(mood);

        if (MatchesAny(input, "how are you"))
        {
            DisplayResponse($"😊 I'm doing great, {userName}! Always ready to help with cybersecurity questions!");
        }
        else if (MatchesAny(input, "what's your purpose", "what is your purpose"))
        {
            DisplayResponse("🔍 My purpose is to guide you on staying safe online, protecting your data, and avoiding threats!");
        }
        else if (MatchesAny(input, "what can i ask you", "help"))
        {
            DisplayResponse("📚 You can ask me about password safety, phishing, scams, privacy, devices, cyber hygiene, online shopping or general cybersecurity tips!");
        }
        else if (MatchesAny(input, "password", "password safety", "tell me about password", "secure my password"))
        {
            favoriteTopic = "Password Security";
            RememberInterest(favoriteTopic);
            DisplayResponse("🔑 Always use strong, unique passwords and never reuse them across multiple accounts. Use a password manager if needed. Also, enable two-factor authentication (2FA) for extra security. If you need help creating a strong password, let me know!");
        }
        else if (MatchesAny(input, "scam", "scam protection", "how to avoid scams"))
        {
            favoriteTopic = "Scam Awareness";
            RememberInterest(favoriteTopic);
            DisplayResponse("🚨 Watch out for scams! Never trust unsolicited requests for personal information or money. Never Share Sensitive Information. Watch for Phishing Links. Verify Before You Trust. Don’t Pay with Gift Cards or Cryptocurrency.");
        }
        else if (MatchesAny(input, "privacy", "privacy tips", "privacy protection", "how to stay private online"))
        {
            favoriteTopic = "Privacy Protection";
            RememberInterest(favoriteTopic);
            DisplayResponse("🔒 Adjust privacy settings on social media and be cautious about the personal info you share online. Think Before You Share. Use Strong, Unique Passwords. Enable 2FA. Review App Permissions. Use Secure Connections. Be Careful with Smart Devices.");
        }
        else if (MatchesAny(input, "phishing", "phishing tip", "phishing safety", "avoid phishing", "phishing scam"))
        {
            favoriteTopic = "Phishing Prevention";
            RememberInterest(favoriteTopic);
            ProvideRandomPhishingTip();
            DisplayResponse("🚫 Phishing is a common tactic used by cybercriminals to trick you into revealing personal information. Always verify the source before clicking on links or providing sensitive data. Hover over links. Watch for urgency. Use anti-phishing tools.");
        }
        else if (MatchesAny(input, "device", "device safety", "device security tips"))
        {
            favoriteTopic = "Device Security Tips";
            RememberInterest(favoriteTopic);
            DisplayResponse("🛡️ Keep your devices secure by regularly updating software, using antivirus programs, and avoiding suspicious downloads. Lock your devices. Use antivirus. Don’t install unknown apps. Use VPNs on public Wi-Fi.");
        }
        else if (MatchesAny(input, "cyber hygiene", "digital hygiene", "online habits"))
        {
            favoriteTopic = "Cyber Hygiene & Habits";
            RememberInterest(favoriteTopic);
            DisplayResponse("🧼 Practice good cyber hygiene: log out of accounts on public devices, review your settings often, reduce account clutter, and educate your loved ones.");
        }
        else if (MatchesAny(input, "online shopping", "shopping scams", "shop safely"))
        {
            favoriteTopic = "Online Shopping & Scams";
            RememberInterest(favoriteTopic);
            DisplayResponse("🛒 Only shop on websites starting with https://. Avoid too-good-to-be-true deals. Use payment services like PayPal. Read reviews before buying.");
        }
        else if (MatchesAny(input, "thank you", "thanks"))
        {
            DisplayResponse($"😊 You're welcome, {userName}! I'm here to help you stay safe online!");
        }
        else if (MatchesAny(input, "what do you remember", "memory"))
        {
            RecallMemory();
        }
        else if (MatchesAny(input, "i don't understand", "explain more", "more details"))
        {
            DisplayResponse($"🧠 No worries, {userName}. Let’s dive deeper into {(string.IsNullOrEmpty(favoriteTopic) ? "cybersecurity" : favoriteTopic)} together!");
        }
        else if (MatchesAny(input, "favorite", "like"))
        {
            DisplayResponse($"❤️ I love talking about {(string.IsNullOrEmpty(favoriteTopic) ? "all cybersecurity topics" : favoriteTopic)}, {userName}!");
        }
        else
        {
            DisplayResponse("🤔 I didn't quite understand that. Could you rephrase your question?");
        }
    }

    static bool MatchesAny(string input, params string[] keywords)
    {
        foreach (var keyword in keywords)
        {
            if (input.Contains(keyword)) return true;
        }
        return false;
    }

    static string DetectCyberSecuritySentiment(string input)
    {
        input = input.ToLower();
        if (input.Contains("worried") || input.Contains("scared") || input.Contains("nervous"))
            return "worried";
        if (input.Contains("curious") || input.Contains("interested") || input.Contains("want to learn"))
            return "curious";
        if (input.Contains("frustrated") || input.Contains("angry") || input.Contains("annoyed"))
            return "frustrated";
        return "neutral";
    }

    static void AdjustMoodResponse(string mood)
    {
        switch (mood)
        {
            case "worried":
                DisplayResponse($"🛡️ It's okay to feel a little worried, {userName}. Cybersecurity can seem complicated, but I'm here to guide you one step at a time!");
                break;
            case "curious":
                DisplayResponse($"🧠 I love your curiosity, {userName}! Asking questions is the best way to get smarter about cybersecurity!");
                break;
            case "frustrated":
                DisplayResponse($"🧘‍♂️ I get it, {userName} — cybersecurity topics can be frustrating. Let's work through it together, calmly and carefully.");
                break;
            default:
                break;
        }
    }

    static void ProvideRandomPhishingTip()
    {
        List<string> phishingTips = new List<string>
        {
            "🎣 Tip: Always double-check the sender's email address before clicking links.",
            "🎣 Tip: Hover over links to preview their actual destination URL.",
            "🎣 Tip: Be suspicious of emails asking for urgent payments or sensitive info.",
            "🎣 Tip: Keep your antivirus software updated to block phishing attempts."
        };
        int index = random.Next(phishingTips.Count);
        DisplayResponse(phishingTips[index]);
    }

    static void ProvideScamSafetyTips()
    {
        List<string> scamTips = new List<string>
        {
            "🔎 Always verify the identity of anyone contacting you unexpectedly.",
            "🚫 Never click on suspicious links or download unknown attachments.",
            "⚠️ Be cautious with urgent messages asking for immediate action.",
            "🔒 Enable two-factor authentication (2FA) on your accounts whenever possible."
        };
        foreach (var tip in scamTips)
        {
            DisplayResponse(tip);
            Thread.Sleep(500);
        }
    }

    static void RememberInterest(string topic)
    {
        if (!userInterests.Contains(topic))
        {
            userInterests.Add(topic);
        }
    }

    static void RecallMemory()
    {
        if (userInterests.Count == 0)
        {
            DisplayResponse($"🤔 I don't have any memories yet, {userName}. Let's learn some cybersecurity topics first!");
        }
        else
        {
            string interests = string.Join(", ", userInterests);
            DisplayResponse($"🧠 {userName}, so far you've shown interest in: {interests}.");
        }
    }

    static void DisplayResponse(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n********💬 ");
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(20); // Typing effect
        }
        Console.WriteLine("\n*********");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
