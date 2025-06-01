using System.Speech.Synthesis;

namespace ZenithVirtualAssistant.Core.Services;

public class TextToSpeechService
{
    private readonly SpeechSynthesizer _synthesizer;

    public TextToSpeechService()
    {
        _synthesizer = new SpeechSynthesizer();
        _synthesizer.SetOutputToDefaultAudioDevice();
    }

    public void Speak(string text)
    {
        _synthesizer.SpeakAsync(text);
    }
}