import { Component, OnInit } from '@angular/core';
import { FormBuilder, ValidationErrors, Validators } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registrationForm = this.fb.group(
    {
      Username: ['', Validators.required],
      Password: ['', Validators.required],
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Email: ['', Validators.email]
    }
  )

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
  }

  checkForm() {
    this.getFormValidationError(['Username','FirstName','LastName','Email']);
    console.log(this.registrationForm.value)
  }

  getFormValidationError(keys) {
    keys.forEach((key, index) => {
      const controlErrors: ValidationErrors = this.registrationForm.get(key)?.errors;
      if (controlErrors)
        console.error(controlErrors);
    })
  }


}
