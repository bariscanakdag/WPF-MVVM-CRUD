   M S B A M L   `   `   `  ����@  <Proje, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Proje.HelperProje.Helper  5          Proje.View.PersonelView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Proje.Helper     5        � 	Resources  5
      '   !Proje.Helper.Base64ImageConverter   Base64ImageConverter$   Proje.Helper.PozisyonConverter  PozisyonConverter��%:   &	        &	        5   
   6%     5   
   6"   5      .��5      � .+�5   
   � $��0,0,0,20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� -   5        $��UserGrid��5      $��1��6'   $��10,171,6,20q�64   ��6I   �� *PersonelList+ �� SelectedItem 6o   �� *	SelecItem+ �� Mode$ TwoWay=� �� View 5      �� 5      -   5        grdTest��.P�5      �� $��Resim��6)    �� Width$	 120��68    �� CellTemplate 5      �� 5   "   .R�5   &   �� ��5   )   �� *
PersonelID+ �� 	Converter# [  5   #   5       �� 5!      $��
PersonelID��6)   $ 80��6k    �� DisplayMemberBinding 6>   �� *
PersonelID+6k   �� 5"      $��Pozisyon��6)   $ 80��6�    6<   �� *
PozisyonID+# [ 6�   �� 5#      $��Cinsiyet��6)   $ 80��6g    6<   �� *
Cinsiyet+6g   �� 5$      $	��Adi��6*   $ 80��6]    67   �� *Adi+6]   �� 5%      $��Soyadi��6)   $	 100��6a    69   �� *Soyadi+6a   �� 5&      $
��Yasi��6)   $	 100��6\    67   �� *Yas+6\   �� 5'       6*   �� *
PozisyonID+# [  5)      5,      �� 5.      $��
Yeni Kişi��6   $
��Left=�6+   $��467,146,0,0q�6F   $��1��6[   $	��Top=�6h   $��76��6�   ��6�   �� *AddPersonelCommand+�� 5/      $��Yukarı��6   $
��Left=�6&   $��
10,146,0,0q�6A   $��1��6U   $	��Top=�6b   $��75��6�   	 J� RenderTransformOrigin$	 	1.587,0.5&�6�   ���	#FF289E69��6z   �� *UpListCommand+6�   �� 50      $��Aşağı��6   $
��Left=�6%   $��
90,146,0,0q�6@   $��1��6T   $	��Top=�6a   $��75��6�   $	 
1.493,0.55&�6�   ���	#FFEE1B54��6y   �� *DownListCommand+6�   �� 51      $��Personel Sil
��6   $
��Left=�66   $��368,146,0,0q�6Q   $��1��6f   $	��Top=�6s   $��75��6�   $��20��6�   ��6�   �� *DeletePersonelCommand+6�   �� 52      $��Personel Edit��6   $
��Left=�6-   $��243,146,0,0q�6H   $��1��6]   $	��Top=�6j   $��85��6�   $��20��6�   ��6�   �� *EditPersonelCommand+6�   54      55      56      