   M S B A M L   `   `   `  ����  AdminModule-    'AdminModule.Views.DeleteView.DeleteView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Sletning��5   	   $��456.717��6   $��477.612��6+   .��5   
   � 
�����_�.+�5   
   �� -   5        $��cbListofTeachers��5      $
��Left=�6,   $��	10,74,0,0q�6G   $	��Top=�6Z   $	��120��6r   ��6~   �� *ListofTeacherEx+ �� SelectedItem 6�   �� *SelectedTeacherEx+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   -   5        $��cbListofClasses��5      $
��Left=�6+   $��	10,74,0,0q�6F   $	��Top=�6Y   $	��120��6q   ��6}   �� *ListofClassEx+ 6�   �� *SelectedClassEx+$ TwoWay=�$ PropertyChanged=�5	      &   System.Windows.Controls.DataGrid  5
   
   -   5        $��datagridClassesEx��5
      $
��Left=�6-   $	��249��6I   $��
215,74,0,0q�6V   $	��Top=�6j   $	��245��6�      AutoGenerateColumns .     CanUserAddRows .  ��6�   �� *ListofRelatedClassesToTeacher+ 6�   �� *ChosenClass+$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6<      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *Id+6H     5      $
 Name��6>    . 	 6%   �� *Name+6L     5      $ 
Underviser��6E    . 	 6%   �� *Fkteacherid+6Y   5      �� 5   
   -   5        $��listboxStudents��5      {�.  $
��Left=�6;   $	��249��6W   $��
215,74,0,0q�6d   $	��Top=�6x   $	��245��6�   ��6�   �� *CurrentClass.StudentsList+�� 5   
   -   5        $��butAssociate��5      $��Tilknyt��6&   $
��Left=�68   $��
135,74,0,0q�6S   $	��Top=�6g   $��75��6   ��6�   �� *AssociateCommand+�� 5   
   $��Annuller��6   $
��Left=�6$   $��385,396,0,0q�6?   $	��Top=�6T   $��75��6l   ��6w   �� *CancelCommand+�� 5   
   $��Bekræft��6   $
��Left=�6#   $��305,396,0,0q�6>   $	��Top=�6S   $��75��6k   ��6v   �� *ConfirmCommand+5      5      