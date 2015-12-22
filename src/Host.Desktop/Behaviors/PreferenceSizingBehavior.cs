using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Interactivity;
using Host.Desktop.Preference.View;
using Host.Desktop.Preference.ViewModel;

namespace Host.Desktop.Behaviors
{
    public class PreferenceSizingBehavior : Behavior<PreferencesView>
    {
        public const double DefaultChildContentWidth = 658;
        public const double DefaultChildContentHeight = 400;

        public static readonly DependencyProperty PreferenceViewModelsProperty =
            DependencyProperty.Register(
                "PreferenceViewModels",
                typeof(ObservableCollection<PreferenceViewModel>),
                typeof(PreferenceSizingBehavior),
                new PropertyMetadata(default(ObservableCollection<PreferenceViewModel>),
                    PreferenceViewModelsPropertyChanged)
                );

        public ObservableCollection<PreferenceViewModel> PreferenceViewModels
        {
            get { return (ObservableCollection<PreferenceViewModel>) GetValue(PreferenceViewModelsProperty); }
            set { SetValue(PreferenceViewModelsProperty, value);}
        }

        public static readonly DependencyProperty MinChildWidthProperty =
            DependencyProperty.Register(
                "MinChildWidth",
                typeof(double),
                typeof(PreferenceSizingBehavior),
                new PropertyMetadata(default(double))
                );

        public double MinChildWidth
        {
            get { return (double) GetValue(MinChildWidthProperty); }
            set { SetValue(MinChildWidthProperty, value);}
        }

        public static readonly DependencyProperty MinChildHeightProperty =
            DependencyProperty.Register(
                "MinChildHeight",
                typeof(double),
                typeof(PreferenceSizingBehavior),
                new PropertyMetadata(default(double))
                );

        public double MinChildHeight
        {
            get { return (double)GetValue(MinChildHeightProperty); }
            set { SetValue(MinChildHeightProperty, value); }
        }

        public static readonly DependencyProperty LargestChildWidthProperty =
            DependencyProperty.Register(
                "LargestChildWidth",
                typeof(double),
                typeof(PreferenceSizingBehavior),
                new PropertyMetadata(default(double))
                );

        public double LargestChildWidth
        {
            get { return (double)GetValue(LargestChildWidthProperty); }
            set { SetValue(LargestChildWidthProperty, value); }
        }

        public static readonly DependencyProperty LargestChildHeightProperty =
            DependencyProperty.Register(
                "LargestChildHeight",
                typeof(double),
                typeof(PreferenceSizingBehavior),
                new PropertyMetadata(default(double))
                );

        public double LargestChildHeight
        {
            get { return (double)GetValue(LargestChildHeightProperty); }
            set { SetValue(LargestChildHeightProperty, value); }
        }

        private NotifyCollectionChangedEventHandler _collectionChangedEventHandler;

        private static void PreferenceViewModelsPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var vms = e.NewValue as ObservableCollection<PreferenceViewModel>;
            var behavior = o as PreferenceSizingBehavior;

            if (vms == null || behavior == null) return;

            SetSize(vms, behavior, behavior.MinChildHeight, behavior.MinChildWidth);

            // remove delegate handler
            vms.CollectionChanged -= behavior._collectionChangedEventHandler;

            // redefine delegate with updates from DependencyProperty
            behavior._collectionChangedEventHandler = delegate
            {
                SetSize(behavior.PreferenceViewModels, behavior, behavior.MinChildHeight, behavior.MinChildWidth);
            };

            // reassign handler to newly defined delegate
            vms.CollectionChanged += behavior._collectionChangedEventHandler;
        }

        private static void SetSize(IEnumerable<PreferenceViewModel> preferenceViewModels,
            PreferenceSizingBehavior preferenceSizingBehavior, double minChildHeight, double minChildWidth)
        {
            if (preferenceViewModels == null || !preferenceViewModels.Any())
            {
                preferenceSizingBehavior.LargestChildWidth = minChildWidth;
                preferenceSizingBehavior.LargestChildHeight = minChildHeight;
                return;
            }

            var biggest = preferenceViewModels.MaxElement(vm => vm.View.Height * vm.View.Width);
            preferenceSizingBehavior.LargestChildHeight = (Double.IsNaN(biggest.View.Height) || biggest.View.Height == 0 ||
                                                           biggest.View.Height < minChildHeight)
                ? minChildHeight
                : biggest.View.Height;
            preferenceSizingBehavior.LargestChildWidth = (Double.IsNaN(biggest.View.Width) || biggest.View.Width == 0 ||
                                                           biggest.View.Width < minChildWidth)
                ? minChildWidth
                : biggest.View.Width;
        }

        private PreferencesView PreferencesView
        {
            get { return AssociatedObject; }
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            SetSize(PreferenceViewModels, this, MinChildHeight, MinChildWidth);
            PreferencesView.Initialized += PreferencesViewOnInitialized;
            PreferencesView.DataContextChanged += PreferencesViewOnDataContextChanged;
            PreferencesView.Unloaded += PreferencesViewOnUnloaded;
        }

        private void PreferencesViewOnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            PreferencesView.Initialized -= PreferencesViewOnInitialized;
            PreferencesView.Unloaded -= PreferencesViewOnUnloaded;
            PreferencesView.DataContextChanged -= PreferencesViewOnDataContextChanged;
            PreferenceViewModels.CollectionChanged -= _collectionChangedEventHandler;
        }

        private void PreferencesViewOnDataContextChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            SetSize(PreferenceViewModels, this, MinChildHeight, MinChildWidth);
        }

        private void PreferencesViewOnInitialized(object sender, EventArgs eventArgs)
        {
            SetSize(PreferenceViewModels, this, MinChildHeight, MinChildWidth);
        }
    }
}
