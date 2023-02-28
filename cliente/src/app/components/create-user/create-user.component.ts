import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { Users } from 'src/app/interfaces/user.interface';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styles: [
  ]
})


export class CreateUserComponent implements OnInit {

  userForm: FormGroup;
  title: string = 'Crear Usurio';
  buttonText: string = 'Crear';

  id: string = '';

  constructor(
    private fb: FormBuilder,
    private serviceUser: UsersService,
    private router: Router,
    private toastr: ToastrService,
    private aRoute: ActivatedRoute
  ) {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      lastName: ['', Validators.required],
      userName: ['', Validators.required],
      age: ['', Validators.required],
      phone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    })

    this.id = this.aRoute.snapshot.paramMap.get('id') || '';
  }

  ngOnInit(): void {
    this.isEdit()
  }

  createUser() {
    const newUser: Users = {
      name: this.userForm.get('name')?.value,
      lastName: this.userForm.get('lastName')?.value,
      username: this.userForm.get('userName')?.value,
      age: this.userForm.get('age')?.value,
      phone: this.userForm.get('phone')?.value,
      email: this.userForm.get('email')?.value,
    }

    if (this.id !== '') {
      newUser.id = this.id;
      this.serviceUser.updateUser(this.id, newUser).subscribe(() => {
        this.toastr.success('User updated successfully', 'User updated');
        this.router.navigate(['/']);
      }, () => {
        this.toastr.error('Error updating user', 'Error');
      })
    } else {
      this.serviceUser.createUser(newUser).subscribe(() => {
        this.toastr.success('User created successfully', 'User created');
        this.router.navigate(['/']);
      }, () => {
        this.toastr.error('Error creating user', 'Error');
      })
    }
  }

  isEdit() {
    if (this.id !== '') {
      this.title = 'Editar Usuario';
      this.buttonText = 'Editar';
      this.serviceUser.getUserById(this.id).subscribe((data) => {
        this.userForm.setValue({
          name: data.name,
          lastName: data.lastName,
          userName: data.username,
          age: data.age,
          phone: data.phone,
          email: data.email,
        })
      })
    }
  }
}
