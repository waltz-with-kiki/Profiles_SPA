import {useState} from "react";
import ProfileItem from "./ProfileItem";
import "./ProfilePage.css";

const ProfilesList = ({remove, ...props}) => {

    return(
        <div className="profiles-list">
            {props.profiles.map((profile) =>
            <ProfileItem remove={remove} profile={profile} key={profile.id}></ProfileItem>) }
        </div>
    );
}

export default ProfilesList;