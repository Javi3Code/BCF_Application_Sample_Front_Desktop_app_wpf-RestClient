   M S B A M L   `   `   `  ����K  GJPA-Porra_Burgos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:JPA_Porra_Burgos.ViewJPA_Porra_Burgos.View  5   	   *    $JPA_Porra_Burgos.View.AppQuestDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   /local#clr-namespace:JPA_Porra_Burgos.View  5   	     � 
ResizeMode$  NoResize=�5	   	    J� 	AllowDrop .  � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������� � AllowsTransparency . 
������  � Title$* $Burgos Club de Fútbol - Aplicación��5   	   $	��250��64   $	��440��6A   .��5      � ���#e02946$��0,0,0,-4q�6    $	��200��62   $	��400��6?   .+�5   
   ��  �� CornerRadius$ 8��6   $��40q�6"   ���#e02946$��-12,-18,-14,-7q�6M   �� 5   
   $��
Un Momento��6   $��28(�6'   $	��Top=�65   $
��Wrap=�6M    �� TextAlignment$ Center=�6b   $
��Bold"�6y   
�������$��	0,0,0.4,0q�6�   $��49��6�   �� 5   
   -   5         ��Name$ txtRMessage��5      +  %MahApps.Metro.Controls.ControlsHelper	   CornerRadius$	 10��6*   {�. 
 �� TextWrapping$

 Wrap=�6c    �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�5       �� 
IsReadOnly . 
�������$
��Left=�6e   $��25(�6�    �� TextAlignment$ Center=�6�   $�� ��6�   $	��Top=�6�   $��95��6�   $	��400��6�   $��0,49,0,0q�6�   �� 5   
   -   5         ��Name$ 	btnAccept��5      $��Aceptar��6$   $��20(�66   $
��Left=�5   .   $��
10,154,0,0q�6`   $	��Top=�5      $	��184��6)   $��40��65      ContentCharacterCasing$ Normal=�6A    �� 	IsDefault .    RecognizesAccessKey .   �� 	ClickMode$ Press=�5   @    � Cursor$
 Hand��5      
�������4  .System.Windows.Automation.AutomationProperties   IsOffscreenBehavior$ Onscreen=�62   
���   ���5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ #e02946��6#    � Offset$ 0Q�63   � 5      $ Black��6#   $ 3Q�61   5       5"      �� 5#   
   -   5        $ 	btnCancel��5#      $��Cancelar��6$    �� IsCancel . $��20(�6G   $
��Left=�5$   .   $��206,154,0,0q�6`   $	��Top=�5%      $	��184��6)   $��40��65   $ Normal=�6A    .  $ Press=�5&   @   $
 Hand��5'      
�������$ Onscreen=�62   
���   ���5(      �� 5)      $ 0.5,1&�6&   $ 0.5,0&�67   .��5*      � $ #e02946��6#   $ 0Q�63   � 5+      $ Black��6#   $ 3Q�61   5,      5.      5/      50      