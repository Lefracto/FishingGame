using Assets.SimpleLocalization.Scripts;

namespace Presentation.Panels
{
  public class SettingsPanel : SimplePanel
  {
    private SavesLoader _savesLoader;
    
    public void ChangeLanguage(string language)
      => LocalizationManager.Language = language;
    
    public void SaveGame()
      => _savesLoader.SaveGame();

    public void SetLoader(SavesLoader savesLoader)
    {
      _savesLoader = savesLoader;
    }
  }
}