import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Users } from 'src/app/interfaces/user.interface';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styles: [
  ]
})
export class ListUserComponent implements OnInit {

  users: Users[] = [];

  constructor(
    private userService: UsersService,
    private toastr: ToastrService

  ) { }


  ngOnInit(): void {
    this.getUser();
  }

  getUser() {
    this.userService.getUsers().subscribe((data) => {
      this.users = data;
    })
  }

  deleteUser(id: string) {
    this.userService.deleteUser(id).subscribe((data) => {
      this.getUser();
      this.toastr.info('User deleted successfully', 'User deleted');
    }, () => {
      this.toastr.error('Error deleting user, Retry again please', 'Error');
    })
  }
}
