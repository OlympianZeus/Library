﻿using Volo.Abp.Settings;

namespace Library.Settings;

public class LibrarySettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(LibrarySettings.MySetting1));
    }
}
