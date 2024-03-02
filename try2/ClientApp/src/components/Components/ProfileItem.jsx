import {useState} from "react";
import MyAvatar from "./UI/MyAvatar";
import "./ProfilePage.css";
import MyButton from "./UI/MyButton";

const ProfileItem = ({remove, ...props}) =>{

    const Delete = (e) =>{
        e.preventDefault();
        const ThisProfile = props.profile.nickName;
        console.log(ThisProfile);
        remove(ThisProfile);
    }

    const data = "/9j...";

      return(
        <div className="profile-item">
            <form className="form">
            <strong>
                {props.profile.nickName}
            </strong>
                  <MyAvatar src={`data:image/jpeg;base64,${props.profile.avatar}`}></MyAvatar>
                  <MyButton onClick={Delete} className="delete-button" style={{ width: '20px', height: '20px' }}></MyButton>
            </form>
        </div>
    );
}

export default ProfileItem;