import {useState, useEffect} from "react";
import MyAvatar from "./UI/MyAvatar";
import "./ProfilePage.css";

const ProfileItem = (props) =>{

    const [avatarUrl, setAvatarUrl] = useState('');

    const data = "/9j...";

      return(
        <div className="profile-item">
            <form className="form">
            <strong>
                {props.profile.nickName}
            </strong>
            <MyAvatar src={`data:image/jpeg;base64,${props.profile.avatar}`}></MyAvatar>
            </form>
        </div>
    );
}

export default ProfileItem;