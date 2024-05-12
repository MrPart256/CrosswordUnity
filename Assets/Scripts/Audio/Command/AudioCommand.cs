public abstract class AudioCommand
{
    public AudioCommand(string sound)
    {
        m_sound = sound;
    }

    protected readonly string m_sound;

    public abstract void Handle(AudioManager audioManager);
}