   M S B A M L   `   `   `  ����L  HFUMiniHotelSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FUMiniHotelSystem.AdminFUMiniHotelSystem.Admin  5      -    'FUMiniHotelSystem.Admin.RoomInfoManager   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:FUMiniHotelSystem.Admin     5        N� Title$  RoomInfoManager��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��73* �6   �� 5      $	��17* �6   .+�5   
   �� -   5        $
��lvRi��5      $��55,136,64,10q�5       �� View 5      �� 5      .P�5      �� $��
RoomNumber��6%    �� Width$	 100��5   %    �� DisplayMemberBinding 5   %   ��  �� Path$ 
RoomNumber��� 5      $��RoomDetailDescription��6%   $	 130��5   %    5   %   �� $ RoomDetailDescription��� 5      $��RoomMaxCapacity��6%   $	 120��5   %    5   %   �� $ RoomMaxCapacity��� 5      $��RoomType��6%   $	 100��5   %    5    %   �� $ RoomTypeName��� 5!      $��
RoomStatus��6%   $	 100��5"   %    5#   %   �� $ Status��� 5$      $��RoomPricePerDay��6%   $	 100��5%   %    5&   %   �� $ RoomPricePerDay�5'      5)      �� 5*   
   -   5        $��	BtnDelete��5*      $��Delete��5+      $
��Left=�5,      $��
573,18,0,0q�5-      $	��Top=�5.      $��36��5/      $	��163��50      
����·�$��Kozuka Mincho Pr6N B)�52      
���   �
�������$��1��55   -   �� 56   
   -   5        $��	BtnUpdate��57      $��Update��56      $
��Left=�58      $��
314,18,0,0q�59      $	��Top=�5:      $��36��5;      $	��163��5<      
����·�$��Kozuka Mincho Pr6N B)�5>      
���   �
�������$��1��5A   -   �� 5B   
   -   5        $��	BtnInsert��5B      $��Create��5C      $
��Left=�5D      $��	55,22,0,0q�5E      $	��Top=�5F      $��36��5G      $	��163��5H      
����·�$��Kozuka Mincho Pr6N B)�5J      
���   �
�������$��1��5M   -   �� 5N   
   $��Manage RoomInformation��6   $
��Left=�5O      $��55,6,0,0q�5P      $	��Top=�5Q      $��43��5R      $��Normal$�5S      $	��292��5T      ���#FFFFFF$��24(�5V      �� 5W   
   -   5        $��tbRoomId��5W      $y�Hidden=�5X      $
��Left=�5Y      $��
528,47,0,0q�5Z       �� TextWrapping$
 Wrap=�5[      $	��Top=�5\      $	��120��5]      ��5^      �� $ RoomId� �� Mode$ OneWay=� � DataContext 5_      �� 	 �� ElementName$
	 lvRi��$ SelectedItem��� 5`   
   -   5        
 ��Name$
 tbSearch��5f      $
��Left=�5`      $��	55,80,0,0q�5a      $
 Wrap=�5b      $	��Top=�5c      $	��163��5d      $��28��5e      5f      �� 5g   
   -   5         ��Name$ 	btnSearch��5k      $��Search��5g      $
��Left=�5h      $��
218,80,0,0q�5i      $	��Top=�5j      $��28��5l      $��49��5m      5n      5o      5p      