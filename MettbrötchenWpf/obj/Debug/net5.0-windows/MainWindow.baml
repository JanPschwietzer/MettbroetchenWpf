   M S B A M L   `   `   `  ����K  GMettbrötchenWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MettbrötchenWpfMettbrötchenWpf  5   	   !    MettbrötchenWpf.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MettbrötchenWpf     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Mettbrötchen��5	   	   $	��210��6   $	��370��6+   .��5
      � $��Center=�6    � RowDefinitions 5   
   �� 5      $��32 �6   �� 5      $��32 �6   �� 5      $��32 �6   �� 5      $��32 �6   �� 5      $��32 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��50 �6   �� 5      $	��140 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��Center=�6   $��Right=�6+   $��Ich bin der Host:��6G   $��0��6c   $��2��6p   $��2��6�   �� 5   
   $��Center=�6   $��Center=�6,   $��
Hostzugang��6I   $��0��6^   $��4��6k   $��2��6{   �� 5    
   $��Center=�6   $��Email��6+   $��1��6;   $��1��6H   �� 5!   
   $��Center=�6   $��1��6-   $��2��6:   $��2��6J   ��6^   �� *	UserEmail+�� 5$   
   $��Center=�6   $��	Brötchen��6+   $��2��6>   $��1��6K   �� 5%   
   $��Center=�6   $��2��6.   $��2��6;   ��6K   �� *BroetchenList+ �� SelectedValue 6r   �� *SelectedBroetchen+�� 5&   
   $��Center=�6   $��2��6+   $��3��68   $��Stück��6H   �� 5)   
   $��Center=�6   $
��Mett��6+   $��3��6:   $��1��6G   �� 5*   
   $��Center=�6   $��3��6.   $��2��6;   ��6K   �� *
MettList+ 6l   �� *SelectedMett+�� 5+   
   $��Center=�6   $��3��6+   $��3��68   $��Gramm��6H   �� 5.   
   $��Center=�6   $��Senden��6,   $��4��6=   $��2��6J   �� 5/   
   $��Center=�6   $��4��6+   $��3��68   ��6H   �� *
StatusText+50      51      