"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.UserDTO = void 0;
var UserDTO = /** @class */ (function () {
    function UserDTO(Id, Email, LastName, FirstName, Address, BloodType, Weight, BirthDate) {
        this.id = Id;
        this.email = Email;
        this.firstName = FirstName;
        this.lastName = LastName;
        this.address = Address;
        this.bloodType = BloodType;
        this.weight = Weight;
        this.birthDate = BirthDate;
    }
    return UserDTO;
}());
exports.UserDTO = UserDTO;
//# sourceMappingURL=userDTO.js.map