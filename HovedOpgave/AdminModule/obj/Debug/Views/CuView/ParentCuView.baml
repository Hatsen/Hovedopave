   M S B A M L   `   `   `  ����  AdminModule$    AdminModule.Views.ParentCuView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  	Forældre��5   	   $��539.885��6   $��671.642��6+   .��5      %  Xceed.Wpf.Toolkit.BusyIndicator     BusyContent$ Vent venligst...��66      IsBusy 6   �� *	Isloading+.��5	   
   � 
�����_�.+�5
      �� $
��Left=�6   $	��365��64   $	��Top=�6A   $	��192��6Y   $��	61,33,0,0q�6e   .+�5      �� $��Fornavn:��6   �� 5      $��23��6    �� TextWrapping$
 Wrap=�6&   $��5,0,5,0q�6z   ��6:   �� *	Firstname+ �� UpdateSourceTrigger$ PropertyChanged=�6z   �� 5      $��
Efternavn:��6   �� 5      $��23��6   $
 Wrap=�6&   $��5,0,5,0q�6{   ��6:   �� *
Lastname+$ PropertyChanged=�6{   �� 5      $	��By:��6   �� 5      $��23��6   $
 Wrap=�6&   $��5,0,5,0q�6v   ��6:   �� *City+$ PropertyChanged=�6v   �� 5      $��Adresse:��6   �� 5      $��23��6   $
 Wrap=�6&   $��5,0,5,0q�6x   ��6:   �� *	Address+$ PropertyChanged=�6x   �� 5      $��Telefonnummer:��6   �� 5      $��23��6   $
 Wrap=�6&   $��5,0,5,0q�6|   ��6:   �� *Phonenumber+$ PropertyChanged=�6|   �� 5      $��Fødselsdag:��6   �� 5      $��23��6   $
 Wrap=�6&   $��5,0,5,0q�6{   ��6:   �� *	Birthdate+$ PropertyChanged=�6{   �� 5      $��Email:��6   �� 5      $��23��6   $
 Wrap=�6&   $��5,0,5,0q�6w   ��6:   �� *Email+$ PropertyChanged=�6w   5      &   System.Windows.Controls.DataGrid  5      $
��Left=�6   $��
290,87,0,0q�62   $	��Top=�6F   $	��244��6^   $	��336��6k      CanUserAddRows .     AutoGenerateColumns .  ��6w   �� *CurrentParentChildrenList+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Fornavn��6G   
   
IsReadOnly
 .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6j      CanUserResize .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *	Firstname+6v     5      $	 	Efternavn��6F   
 . $	 100 6k    .   6)   �� *
Lastname+6w     5       $	 By��6B   
 . $	 100 6`    .   6)   �� *City+6l     5!      $	 	FkClassid��6G   
 . $	 100 6l    .   6)   �� *	FkClassid+6x      RowDetailsTemplate 5#      �� 5$      .R�5%      �� $��0q�6!   
������� �� Padding$ 10q�6L   ._�5&      ��  �� Orientation$ Vertical=�6)   .+�5'   "   �� $ 
Horizontal=�6-   .+�5(   &   �� $��12(�60   $
��Id: ��6>   $��Center=�6J   �� 5)   &   $��16(�60   
���p�$��Center=�6l   ��6X   �� *Id+6l   5*   #   �� 5+   "   $ 
Horizontal=�6-   .+�5,   &   �� $��12(�60   $��Seneste login: ��6>   $��Center=�6U   �� 5-   &   $��16(�60   
���p�$��Center=�6s   ��6X   �� *	Lastlogin+6s   5.   #   �� 5/   "   $ 
Horizontal=�6-   .+�50   &   �� $��12(�60   $��
Userrole: ��6>   $��Center=�6P   �� 51   &   $��16(�60   
���p�$��Center=�6r   ��6X   �� *
Userrole+6r   52   #   �� 53   "   $ 
Horizontal=�6-   .+�54   &   �� $��12(�60   $��
Username: ��6>   $��Center=�6P   �� 55   &   $��16(�60   
���p�$��Center=�6r   ��6X   �� *
Username+6r   56   #   �� 57   "   $ 
Horizontal=�6-   .+�58   &   �� $��12(�60   $��	Telefon: ��6>   $��Center=�6O   �� 59   &   $��16(�60   
���p�$��Center=�6u   ��6X   �� *Phonenumber+6u   5:   #   5;      5<      5=      5@      �� 5B      $
��Left=�6   $��
290,60,0,0q�62   $	��Top=�6F   $	��131��6^    J� RenderTransformOrigin$ 	0.492,0.5&�6j   ��6�   �� *	ClassList+$ TwoWay=� �� SelectedItem 6�   �� *SelectedClass+$ TwoWay=�$ PropertyChanged=��� 5C      $
��Left=�6   $��
426,60,0,0q�62   $	��Top=�6F   $	��120��6^   ��6k   �� *ChildrenList+$ TwoWay=� 6�   �� *SelectedChild+$ TwoWay=�$ PropertyChanged=��� 5D      $ 
Horizontal=�6   $
��Left=�62   $��50��6M   $	��Top=�6Y   $	��269��6q   $��
61,403,0,0q�6}   .+�5E      �� $��Bekræft��6   $��23��6+   $
��0,12q�6\   $��80��6j   ��69   �� *ConfirmCommand+6j   �� 5F      $��Annuller��6   $��23��6,   $��
10,12,0,11q�6\   $��80��6p   ��69   �� *CancelCommand+6p   5G      �� 5H      $��Tilknyt��6   $
��Left=�6'   $	��Top=�6C   $��75��6[   $ 1.093,-0.15&�6f   $��
551,60,0,0q�6�   $��22��6�   ��6�   �� *AssociateCommand+�� 5I      $
��Left=�6   $��
295,38,0,0q�63   $
��Wrap=�6G   $��Klasse:��6[   $	��Top=�6j   �� 5J      $
��Left=�6   $��
426,38,0,0q�63   $
��Wrap=�6G   $��Elev:��6[   $	��Top=�6h   5N      5P      5Q      