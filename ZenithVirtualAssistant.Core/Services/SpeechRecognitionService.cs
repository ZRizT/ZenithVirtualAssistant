using System;
using System.Speech.Recognition;
using System.Threading.Tasks;

namespace ZenithVirtualAssistant.Core.Services;

public class SpeechRecognitionService
{
    private readonly SpeechRecognitionEngine _recognizer;
    private readonly AIService _aiService;
    private bool _isListening;

    public event EventHandler<string>? CommandRecognized;

    public SpeechRecognitionService(AIService aiService)
    {
        _aiService = aiService;
        _recognizer = new SpeechRecognitionEngine();
        InitializeRecognizer();
    }

    private void InitializeRecognizer()
    {
        var grammar = new Grammar(new GrammarBuilder("zenith"));
        _recognizer.LoadGrammar(grammar);
        _recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
        _recognizer.SetInputToDefaultAudioDevice();
    }

    private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        if (_isListening && e.Result.Text.StartsWith("zenith", StringComparison.OrdinalIgnoreCase))
        {
            CommandRecognized?.Invoke(this, e.Result.Text);
        }
    }

    public void StartListening()
    {
        _isListening = true;
        _recognizer.RecognizeAsync(RecognizeMode.Multiple);
    }

    public void StopListening()
    {
        _isListening = false;
        _recognizer.RecognizeAsyncStop();
    }
}