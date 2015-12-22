using System;

namespace Host.Desktop.Preference
{
    public interface IPreferencesService
    {
        IPreference Preference(string name);
    }

    public sealed class FluentPreferencesService : IPreferencesService
    {
        private readonly Action<IPreferenceRegister> _addAction;

        public FluentPreferencesService(Action<IPreferenceRegister> addAction)
        {
            _addAction = addAction;
        }

        public IPreference Preference(string name)
        {
            return new FluentPreference(name, _addAction);
        }
    }
}
