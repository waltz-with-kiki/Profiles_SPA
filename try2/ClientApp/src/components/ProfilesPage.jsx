import { useState, useEffect } from "react";
import ProfileForm from "./Components/ProfileForm";
import ProfilesList from "./Components/ProfilesList";

const ProfilesPage = () => {
    const [Profiles, setProfiles] = useState([]);

    /*const createProfile = (profile) => {
        setProfiles([...Profiles, profile]);
    }*/

    const removeProfile = async (profilenickName) => {

        console.log(profilenickName);
        
        const response = await fetch('https://localhost:7150/api/accounts/profiles/remove', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({nickName: profilenickName
                }),
            });
        
        
        //const UpdateProfiles = Profiles.filter((element) => element.nickName !== profilenickName);


        //setProfiles(UpdateProfiles);

        //console.log(Profiles);
        fetchProfiles();
    }

    const createProfile = async (profile) => {
        try {

            console.log(profile);
            console.log(profile.nickName);
            
            const response = await fetch('https://localhost:7150/api/accounts/profiles', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({NickName: profile.nickName,
                                      Avatar: profile.Avatar,
                                      TimeCreate: new Date().toISOString()
                }),
            });
    
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
    
            console.log('Profile added successfully!');
            // После успешного добавления профиля, вызываем метод GET для обновления списка
            fetchProfiles();
        } catch (error) {
            console.error('Error adding profile:', error);
        }
    };

    useEffect(() => {
        // Вызов метода GET при монтировании компонента
        fetchProfiles();
      }, []);

      const fetchProfiles = async () => {
          try {
              fetch('https://localhost:7150/api/accounts/profiles')
                  .then(response => response.json())
                  .then(data => console.log(data))
                  .catch(error => console.error('Error fetching data:', error));
            const response = await fetch('https://localhost:7150/api/accounts/profiles'); // Путь к вашему методу GET
          const data = await response.json();
          setProfiles(data);
        } catch (error) {
          console.error("Error fetching users:", error);
        }
      };
    
      //<input value={nickName} onChange={(e) => SetnickName(e.target.value)}></input>
    return (
        <div>
            <ProfileForm create={createProfile}></ProfileForm>
            <ProfilesList remove={removeProfile} profiles={Profiles}></ProfilesList>

          
        </div>
    );
}

export default ProfilesPage;