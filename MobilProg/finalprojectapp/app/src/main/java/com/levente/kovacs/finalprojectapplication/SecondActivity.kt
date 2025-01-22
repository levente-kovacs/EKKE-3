package com.levente.kovacs.finalprojectapplication

import RecycleAdapter
import android.content.Intent
import android.os.Bundle
import android.view.KeyEvent
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class SecondActivity : AppCompatActivity() {

    private lateinit var recyclerView: RecyclerView
    private lateinit var adapter: RecycleAdapter
    private val rows = mutableListOf<String>(
        "Dashing through the snow",
        "In a one-horse open sleigh",
        "O'er the fields we go",
        "Laughing all the way.",
        "The bells on bob-tail ring",
        "They make our spirits bright",
        "What fun it is to ride and sing",
        "A sleighing song tonight.",
        "Jingle bells, jingle bells",
        "Jingle all the way,",
        "Oh, what fun it is to ride",
        "In a one-horse open sleigh!",
        "Jingle bells, jingle bells",
        "Jingle all the way,",
        "Oh, what fun it is to ride",
        "In a one-horse open sleigh!"
    )

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.second_activity)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

//        val rows = arrayOf(
//            "Dashing through the snow",
//            "In a one-horse open sleigh",
//            "O'er the fields we go",
//            "Laughing all the way.",
//            "The bells on bob-tail ring",
//            "They make our spirits bright",
//            "What fun it is to ride and sing",
//            "A sleighing song tonight.",
//            "Jingle bells, jingle bells",
//            "Jingle all the way,",
//            "Oh, what fun it is to ride",
//            "In a one-horse open sleigh!",
//            "Jingle bells, jingle bells",
//            "Jingle all the way,",
//            "Oh, what fun it is to ride",
//            "In a one-horse open sleigh!"
//        )


        val textView2: TextView = findViewById(R.id.textView2)
        // val textView3: TextView = findViewById(R.id.textView3)

        val editText4: EditText = findViewById(R.id.editText4)

        val text1 = intent.getStringExtra("TEXT1") ?: "Error receiving text1."
        val text2 = intent.getStringExtra("TEXT2") ?: "Error receiving text2."

        val button3: Button = findViewById(R.id.button3)

        textView2.text = text1
        // textView3.text = text2

        editText4.setText(text2)

        adapter = RecycleAdapter(rows)
        recyclerView = findViewById(R.id.recyclerView)

        recyclerView.layoutManager = LinearLayoutManager(this)
        recyclerView.adapter = adapter

        editText4.setOnKeyListener { _, keyCode, event ->
            if (keyCode == KeyEvent.KEYCODE_ENTER && event.action == KeyEvent.ACTION_UP) {
                val editTextValue = editText4.text.toString().trim()
                if (editTextValue.isNotEmpty()) {
                    addItemToRecyclerView(editTextValue)
                    editText4.text.clear()
                }
                // return@setOnKeyListener true
            }
            false
        }

        button3.setOnClickListener {
            val intent = Intent(this, SensorActivity::class.java)
            startActivity(intent)
        }
    }

    private fun addItemToRecyclerView(row: String) {
        rows.add(row)
        adapter.notifyItemInserted(rows.size - 1)
        recyclerView.scrollToPosition(rows.size - 1)
    }

}