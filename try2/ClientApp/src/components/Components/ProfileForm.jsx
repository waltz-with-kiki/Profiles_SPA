import { useState } from "react";
import MyInput from "./UI/MyInput";
import MyAvatar from "./UI/MyAvatar";
import MyButton from "./UI/MyButton";
import "./ProfilePage.css";
import ProfileItem from "./ProfileItem";
import AvatarUploader from "./AvatarUploader";

const ProfileForm = ({create, ...props}) => {

    const [Profile, setProfile] = useState({nickName: '', src: ""});

    const SetAvatar = (avatar) => {
        setProfile({ ...Profile, Avatar: avatar});
    };

    const AddProfile = (e) =>{
        e.preventDefault();
        const ProfileItem = {
            ...Profile,
        }
        if(ProfileItem.nickName.length === 0){
            ProfileItem.nickName = "404 exception";
        };
        create(ProfileItem);
        setProfile({nickName: ''});
    }

    return(
        <div>
            <form >
            <MyInput style={{marginBottom: '10px'}} placeholder="Никнейм" value={Profile.nickName} onChange={e => setProfile({...Profile, nickName: e.target.value})}></MyInput>
            <AvatarUploader setavatar={SetAvatar}></AvatarUploader>
            <MyButton style={{marginBottom: '10px'}} onClick={AddProfile}>Add</MyButton>
            </form>
        </div>
    );
}

export default ProfileForm;