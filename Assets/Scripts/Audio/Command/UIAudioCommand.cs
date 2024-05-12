public class UIAudioCommand : AudioCommand
{
    public UIAudioCommand(string sound) : base(sound)
    {
    }

    public override void Handle(AudioManager audioManager)
    {
        audioManager.PlayUISound(m_sound);
    }
}