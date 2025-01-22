package com.levente.kovacs.finalprojectapplication

import android.Manifest
import android.content.Intent
import android.net.Uri
import android.content.pm.PackageManager
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import androidx.core.content.ContextCompat
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat


class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val btn1: Button = findViewById(R.id.button1)
        val btn2: Button = findViewById(R.id.button2)
        // val textView1: TextView = findViewById(R.id.textView1)
        val editText1: EditText = findViewById(R.id.editText1)
        val editText2: EditText = findViewById(R.id.editText2)

        btn1.setOnClickListener {
            // textView1.text = btn1.text

            val phoneNumber = "112233445566"
            val intent = Intent(Intent.ACTION_CALL, Uri.parse("tel:$phoneNumber"))

            if (ContextCompat.checkSelfPermission(this, Manifest.permission.CALL_PHONE) == PackageManager.PERMISSION_GRANTED
            ) {
                startActivity(intent)
            } else {
                ActivityCompat.requestPermissions(this, arrayOf(Manifest.permission.CALL_PHONE), 1)
            }
        }

        btn2.setOnClickListener {
            // textView1.text = btn2.text

            val text1 = editText1.text.toString()
            val text2 = editText2.text.toString()

            val intent = Intent(this, SecondActivity::class.java).apply {
                putExtra("TEXT1", text1)
                putExtra("TEXT2", text2)
            }
            startActivity(intent)
        }
    }
}