   M S B A M L   `   `   `  ����  AdminModule%    AdminModule.Views.TeacherCuView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  Ansat��5   	   $��547.218��6   $	��300��6(   .��5      %  Xceed.Wpf.Toolkit.BusyIndicator     BusyContent$ Opretter Underviser...��66      IsBusy 6   �� *	Isloading+.��5
   
   � 
�����_�.+�5      �� $��Center=�6   $	��412��66   $	��Top=�6C   $	��192��6[   $��
61,33,39,0q�6g   .+�5      �� $��Fornavn:��6   �� 5      $��23��6    �� TextWrapping$
 Wrap=�6&   $��5,0,5,0q�6z   ��6:   �� *	Firstname+ �� UpdateSourceTrigger$ PropertyChanged=�6z   �� 5      $��
Efternavn:��6   �� 5      $��23��6   $
 Wrap=�6&   $��5,0,5,0q�6{   ��6:   �� *
Lastname+$ PropertyChanged=�6{   �� 5      $	��By:��6   �� 5      $��23��6   $
 Wrap=�6&   $��5,0,5,0q�6v   ��6:   �� *City+$ PropertyChanged=�6v   �� 5      $��Adresse:��6   �� 5      $��23��6   $
 Wrap=�6&   $��5,0,5,0q�6x   ��6:   �� *	Address+$ PropertyChanged=�6x   �� 5      $��Fødselsdag:��6   �� 5      $��23��6   $
 Wrap=�6&   $��5,0,5,0q�6{   ��6:   �� *	Birthdate+$ PropertyChanged=�6{   �� 5      $��Telefon nummer:��6   �� 5      $��23��6   $
 Wrap=�6&   $��5,0,5,0q�6}   ��6:   �� *Phonenumber+$ PropertyChanged=�6}   �� 5      $��Email:��6   �� 5      $��23��6   $
 Wrap=�6&   $��5,0,5,0q�6w   ��6:   �� *Email+$ PropertyChanged=�6w   �� 5      $��Rang/stilling:��6   �� 5      $��5,0,5,0q�6   ��6-   �� *Ranks+ �� Mode$ TwoWay=� �� SelectedItem 6X   �� *SelectedRank+5      �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��61��6O   $	��Top=�6[   $	��192��6s   $��61,445,39,0q�6   .+�5      �� $��Bekræft��6   $��23��6+   $��70��67   $��
10,19,0,19q�6C   ��6W   �� *ConfirmCommand+�� 5       $��Annuller��6   $��23��6,   $��70��68   $��
30,19,0,19q�6C   ��6W   �� *CancelCommand+5!      5#      5$      5)      