   M S B A M L   `   `   `  ����H  DBankConverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BankConverterBankConverter  5   	   A%clr-namespace:BankConverter.ViewModelBankConverter.ViewModel  5   	   #    BankConverter.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:BankConverter     5   	   <
viewmodels%clr-namespace:BankConverter.ViewModel     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � DataContext 5
      +   %BankConverter.ViewModel.MainViewModel  5   
   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��0.5* �6   �� 5      .+�5   
   � $��10q�6   $��0��6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      �� 5      $
��auto �6    .+�5      �� $��20(�6j    �� DisplayMemberPath$
 Name��6x   $��1��6�   $��0,115,0,198q�6�   ��6   �� *Valute.Valute+ �� SelectedValue 6=   �� *FirstSelectedValue+6�   �� 5      $��20(�6_   $��1��6m   $��0,165,0,138q�6z   ��6   �� *num1+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6z   �� 5      $��2��6   5      � 5   
   $��10q�6   $��1��6   $��Center=�6+   .+�5       (  "System.Windows.Controls.DatePicker     SelectedDate 6   �� *SelectedDate+6A   5!      � 5"   
   $��10q�6   $��2��6    5#      �� 5$      $
��auto �6    �� 5%      �� 5&      $
��auto �6    .+�5(      �� $��20(�6k   $��1��6y   $
 Name��6�   $��0,115,0,198q�6�   ��6   �� *Valute.Valute+ 6=   �� *SecondSelectedValue+6�   �� 5)      $��20(�6^   $��1��6l   $��0,165,0,138q�6y   ��6   �� *num2+$ OneWay=�$ PropertyChanged=�6y   �� 5*      $��2��6   5+      �� 5,   
   $
��Swap��6   $��1��69   $��Center=�6I   $��30,130,30,228q�6d   	 J� RenderTransformOrigin$	 	0.053,0.8&�6{   $��41��6�   ��6    �� *Swap+6�   5.      5/      