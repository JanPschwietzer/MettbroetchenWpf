   M S B A M L   `   `   `  ���� K  GMettbrötchenWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MettbrötchenWpfMettbrötchenWpf  '    !MettbrötchenWpf.EinladungsWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  *localclr-namespace:MettbrötchenWpf    � Title$  Einladen��$	��350��$	��400�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � AllowsTransparency$
 True��
������  � WindowStartupLocation$ CenterOwner=� � DataContext 0   *MettbrötchenWpf.EinladungsWindowViewModel  .���� 
���   �
���   �$	��0.5q� �� Padding$ 1q�._��� ���#bfc0c0 � Cursor$ Arrow��.+��  � RowDefinitions �� $��50 ��� $	��300 �	 � ColumnDefinitions	 �� �� .+�� ���#2d3142$��3��	 �� �� .+��� -   $ SizeAll�����#FCFCFC$��15(�$
��Bold"�$��Center=�$
��Left=�$��Mettbrötchen: Einladen��$��0��$��0��$��10��$��6q�$	��289��$��36��$��10,0,0,0q��� -   $��Center=�$��0��$��1��$��0 0 5 0 q�$��Right=� 0  ,MaterialDesignFloatingActionMiniAccentButton#��[  ��Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Power=����#FCFCFC$��25��$��25���� $��1��$��0��$��
25 25 25 0q�$��2��.+�]� .+��� $��Datum:��$��0 0 50 0q��� $��Right=����� *Datum+]� $��0 25 0 0q�.+��� $��Center=�$��Anmeldeschluss:��$��0 0 50 0q�]� $��Right=�.+��� $��Center=�$��Right=�$��25�� �� TextAlignment$ Center=����� *Stunde+�� $��Center=�$��Right=�$��25��$ Center=����� *Minute+�� $��Center=�$
�� Uhr��$��5 0 0 0q��� $��15 50 15 15q�$��Center=�$��Mitteilungen senden��
���   ����#ef8354���#ef8354���� * SendNotificationsButtonCommand+�� $��
15 0 15 15q�$��Center=�$��Emails senden��${�False��
���   ����#ef8354���#ef8354���� * SendNotificationsButtonCommand+�� $��Center=����� *Status+