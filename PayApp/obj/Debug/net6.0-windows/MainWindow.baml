   M S B A M L   `   `   `  ����A  =PayApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PayAppPayApp  5   	       PayApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:PayApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��50q�6    � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��UserList��5      $��0��6A   $��5��6N   ��6#   �� *Users+ �� SelectedItem 6_   �� *SelectedUser+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ Stretch=�6C   5       �� View 5      �� 5      .P�5       �� $
��Naam��6%    �� Width$
 auto��6Y   	 �� DisplayMemberBinding	 63   �� *Name+6Y   �� 5!      $��Credits��6%   $
 auto��6e   	 66   �� *CreditsString+6e   �� 5"      $��Doet mee��6%   
 �� CellTemplate
 5#      �� 5$      .R�5%   "   ��  d� 	IsChecked 6+   �� *Joins+5&      5(      5)      5+      �� 5,   
   $��1��6   $��1��6%    �� Orientation$ 
Horizontal=�62   .+�5-      �� -   5        $��	Toevoegen��5-      $��3q�69   6F   �� 5.      -   5        $��	Aanpassen��5.      $��3q�6:   6G   �� 5/      -   5        $��Verwijderen��5/      $��3q�6>   6K   50      �� 51   
   $��2��6   $��2��6%   $ 
Horizontal=�62   .+�52      �� -   5        $��Bereken��52      $��3q�6@   6M   �� 53      $��3q�69   ��6   �� *PayingUser.Name+69   54      �� 55   
   $ 
Horizontal=�6   $��1��6.   $��3��6>   .+�56      �� $��Prijs:��6   $��3q�6&   �� 57      $��3q�63   $��55��6>   ��6   �� *PriceString+6>   �� 58      -   5        $��Betaal��58      $��3q�62   6?   59      5:      5;      