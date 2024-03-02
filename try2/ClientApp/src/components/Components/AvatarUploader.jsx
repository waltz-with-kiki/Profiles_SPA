import React, { useState } from 'react';
import MyAvatar from './UI/MyAvatar';

const AvatarUploader = ({setavatar}) => {
  const [src, setSrc] = useState(null);
 //const [src, Setsrc] = useState("");

  /*
  const handleFileChange = (event) => {
    const selectedFile = event.target.files[0];
    if (selectedFile) {
      // Можете здесь выполнить дополнительные проверки, например, на тип файла или размер

      // Чтение файла и установка его в состояние
      const reader = new FileReader();
      reader.onload = () => {
        setAvatar(reader.result);
      };
      reader.readAsDataURL(selectedFile);

      const src = URL.createObjectURL(selectedFile);
      setavatar(src);
    }
  };
  */


  const handleFileChange = (event) => {
    const selectedFile = event.target.files[0];
    if (selectedFile) {
        const reader = new FileReader();

        reader.onload = () => {
            setSrc(reader.result);
            console.log("Первое" + reader.result)
            const base64String = reader.result.split(',')[1]; // Отсекаем "data:image/jpeg;base64," или подобное

            setavatar(base64String);
        };

        reader.readAsDataURL(selectedFile);
    }
};

const convertBase64ToByteArray = (base64String) => {
    const binaryString = atob(base64String);
    const byteArray = new Uint8Array(binaryString.length);

    for (let i = 0; i < binaryString.length; i++) {
        byteArray[i] = binaryString.charCodeAt(i);
    }

    return byteArray;
};
  

  return (
    <div>
      <input type="file" onChange={handleFileChange} accept="image/*" />
      {src && (
        <div>
          <p>Выбранное изображение:</p>
          <MyAvatar src={src} alt="Выбранный аватар"></MyAvatar>
        </div>
      )}
    </div>
  );
};

export default AvatarUploader;